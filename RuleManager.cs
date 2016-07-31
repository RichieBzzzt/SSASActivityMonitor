//-----------------------------------------------------------------------
//  This file is part of the Microsoft Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading;

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{
    /// <summary>
    /// delegate to get data from the server
    /// </summary>
    /// <returns>A DataTable from the server</returns>
    public delegate DataTable DataDel();

    /// <summary>
    /// A class to manage and process rules in a seperate thread
    /// </summary>
    public class RuleManager :IDisposable
    {

        #region Member Variables
        /// <summary>
        /// The list of rules this rule manager is managing
        /// </summary>
        private List<Rule> rules;
        /// <summary>
        /// A delegate that tells the rule manager where to get data to process rules on
        /// </summary>
        internal DataDel getData;
        /// <summary>
        /// A delegate that tells rules how to kill sessions
        /// </summary>
        internal ActionDel kill;
        /// <summary>
        /// A delegate that tells rules how to add an alert
        /// </summary>
        internal ActionDel alert;
        /// <summary>
        /// A delegate that tells rules where to egt their own data
        /// </summary>
        internal QueryToData ruleGetData;

        /// <summary>
        /// The timer to control when to process rules
        /// </summary>
        private Timer timer;
        /// <summary>
        /// The interval to control how often to process rules
        /// </summary>
        private int interval = 90000;

        #endregion

        #region constructors

        /// <summary>
        /// Constructs a new RuleManager with default process interval
        /// </summary>
        public RuleManager()
        {
            rules = new List<Rule>();
        }

        /// <summary>
        /// Constructs a new RuleManager with a given process interval
        /// </summary>
        /// <param name="_interval">The interval on which to process rules in milliseconds</param>
        public RuleManager(int interval)
        {
            this.interval = interval;
        }

        ~RuleManager()
        {
            Stop();
        }

        #endregion

        #region threading / timer

        /// <summary>
        /// Starts periodically processing rules in a seperate thread
        /// </summary>
        public void Start()
        {
            timer = new Timer(ProcessRules, null, interval, interval);
        }

        /// <summary>
        /// Stop the RuleManager from processing rules
        /// </summary>
        public void Stop()
        {
            if (timer != null)
                timer.Dispose();
        }

        #endregion

        #region Callback Function

        /// <summary>
        /// Callback function to process rules to be set to run on timer tick
        /// </summary>
        /// <param name="o">Dummy paramneter to fit delegate</param>
        private void ProcessRules(object o)
        {
            //get data and process every rule on every row
            try
            {
                DataTable data = getData();

                //clear alert list and process rules
                //alert(null, null);
                foreach (Rule rule in rules)
                    rule.Process(null);
                foreach (DataRow row in data.Rows)
                    foreach (Rule rule in rules)
                        rule.Process(row);
            }
            catch { }
        }

        #endregion

        #region Management Functions

        /// <summary>
        /// returns an array of rules managed by this class
        /// </summary>
        /// <returns></returns>
        public Rule[] GetRules()
        {
            return rules.ToArray();
        }

        /// <summary>
        /// adds a rule to be managed, does not allow uplicates
        /// </summary>
        /// <param name="rule">The rule to attempt to add</param>
        public void AddRule(Rule rule)
        {
            if (rules.Exists(r => r.Equals(rule)))
                throw new ArgumentException("Rule Already exists");
            rules.Add(rule);
        }

        /// <summary>
        /// Converts a string to a rule and attempts to add it.
        /// Does not allow duplicate rules to be managed
        /// </summary>
        /// <param name="rule">The string to convert into a rule and add to the manager</param>
        /// <returns></returns>
        public Rule AddRule(string rule)
        {
            Rule returned;
            if (rules.Exists(r => r.ToString().Equals(rule)))
                throw new ArgumentException("Rule Already exists");

            returned = StringToRule(rule);
            rules.Add(returned);

            return returned;
        }

        /// <summary>
        /// Removes a rule from the manager
        /// </summary>
        /// <param name="rule">The rule to remove</param>
        public void RemoveRule(Rule rule)
        {
            rules.Remove(rule);
        }

        /// <summary>
        /// Parses a properly formatted string into a rule
        /// </summary>
        /// <param name="rule">the string to convert to a rule</param>
        /// <returns></returns>
        public Rule StringToRule(string rule)
        {
            string[] parts;

            if (rule.StartsWith("WHERE"))
            {
                parts = rule.Split(new string[] { "WHERE ", " THEN " }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                    throw new ArgumentException("Invalid rule");
                return new WhereRule(ruleGetData, parts[0], StringToActions(parts[1]));
            }

            parts = rule.Split(new string[] { "IF ", " THEN " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new ArgumentException("Invalid rule");

            return new Rule(StringToCon(parts[0]), StringToActions(parts[1]));

        }

        /// <summary>
        /// Helper recursive function to parse conditions
        /// </summary>
        /// <param name="con">the condition to parse</param>
        /// <returns>a Condition to add into a rule</returns>
        private Condition StringToCon(string con)
        {
            if (String.IsNullOrEmpty(con))
                throw new ArgumentException("Invalid Condition");

            //check if given condition has an AND
            string[] buff = con.Split(new string[] { " AND " }, 2, StringSplitOptions.None);
            if (buff.Length == 2)
                return new AndCondition(StringToCon(buff[0]), StringToCon(buff[1]));

            //no AND, check for OR
            buff = con.Split(new string[] { " OR " }, 2, StringSplitOptions.None);
            if (buff.Length == 2)
                return new OrCondition(StringToCon(buff[0]), StringToCon(buff[1]));

            //check for NOT condition
            buff = con.Split(new string[] { "NOT " }, 2, StringSplitOptions.None);
            if (buff.Length != 1)
                return new NegCondition(StringToCon(buff.Single(s => !String.IsNullOrEmpty(s))));

            //check for TOTAL condition
            buff = con.Split(new string[] { "USER-TOTAL " }, 2, StringSplitOptions.None);
            if (buff.Length != 1)
            {
                ColumnCondition colcon = (ColumnCondition)StringToCon(buff.Single(s => !String.IsNullOrEmpty(s)));
                return new TotalCondition("SESSION_USER_NAME", colcon.colName, colcon.op, colcon.arg);

            }

            //check for match in set condition
            buff = con.Split(new string[] { " IN " }, 2, StringSplitOptions.None);
            if (buff.Contains(""))
                throw new ArgumentException("Invalid Column IN Set Condition");
            else if (buff.Length == 2)
                return new MatchColInSetCondition(buff[0].Trim(), buff[1].Split(new char[] { '{', '}', ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries));

            //check for column condition
            buff = con.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (buff.Length != 3)
                throw new ArgumentException("Invalid Column Condition");
            else
            {
                RuleOperator op;
                switch (buff[1])
                {
                    case "<":
                        op = RuleOperator.lt;
                        break;
                    case "<=":
                        op = RuleOperator.lte;
                        break;
                    case "==":
                    case "=":
                        op = RuleOperator.eq;
                        break;
                    case ">=":
                        op = RuleOperator.gte;
                        break;
                    case ">":
                        op = RuleOperator.gt;
                        break;
                    default:
                        throw new ArgumentException("Illegal Operator to Column Condition");
                }
                try
                {
                    return new ColumnCondition(buff[0], op, float.Parse(buff[2]));
                }
                catch
                {
                    throw new ArgumentException("Illegal Argument to Column operator");
                }
            }

        }

        /// <summary>
        /// Helper method to parse a string into rule actions
        /// </summary>
        /// <param name="acts">the string to parse into actions</param>
        /// <returns>An array of the parsed actions</returns>
        private Action[] StringToActions(string acts)
        {
            //split string by ANDs
            string[] buff = acts.Split(new string[] { " AND " }, StringSplitOptions.None);
            if (buff.Contains(""))
                throw new ArgumentException("Illegal AND statement in actions");

            //check each split string to match a valid action
            Action[] returned = new Action[buff.Length];
            for (int c = 0; c < buff.Length; c++)
            {
                if (buff[c].Contains("NOTIFY"))
                    returned[c] = new AlertAction(alert);
                else if (buff[c].Contains("ALERT"))
                    returned[c] = new AlertAction(alert);
                else if (buff[c].Contains("KILL"))
                    returned[c] = new CancelAction(kill);
                else
                    throw new ArgumentException("Unsupported Action");
            }

            return returned;
        }

        /// <summary>
        /// Change the interval on the timer
        /// </summary>
        /// <param name="newInterval">the new interval for the timer</param>
        public void ChangeTimer(int newInterval)
        {
            interval = newInterval;
            timer.Change(newInterval, newInterval);
        }

        #endregion

        #region Configuration Functions

        /// <summary>
        /// Save each rule to the configuration file
        /// </summary>
        /// <param name="writer">the writer to save rules with</param>
        public void SaveConfigData(XmlWriter writer)
        {
            foreach (Rule r in rules)
            {
                writer.WriteElementString("Rule", @r.ToString());
                writer.WriteElementString("Priority", r.priority.ToString());
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (timer != null)
                timer.Dispose();
        }

        #endregion
    }
}
