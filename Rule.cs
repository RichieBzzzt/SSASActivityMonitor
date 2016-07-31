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

namespace Microsoft.AnalysisServices.Samples.ActivityViewer
{

    public enum RuleOperator
    {
        lt,
        lte,
        eq,
        gte,
        gt
    }

#region conditions
    public abstract class Condition
    {
        public static bool ApplyOperator(float lhs, RuleOperator op, float rhs)
        {
            switch (op)
            {
                case RuleOperator.lt:
                    return lhs < rhs;
                case RuleOperator.lte:
                    return lhs <= rhs;
                case RuleOperator.gt:
                    return lhs > rhs;
                case RuleOperator.gte:
                    return lhs >= rhs;
                default:
                    return lhs == rhs;
            }
        }

        public static string OperatorToString(RuleOperator op)
        {
            switch (op)
            {
                case RuleOperator.lt:
                    return "<";
                case RuleOperator.lte:
                    return "<=";
                case RuleOperator.gt:
                    return ">";
                case RuleOperator.gte:
                    return ">=";
                default:
                    return "=";
            }
        }

        public abstract bool Verify(DataRow row);
        public abstract override string ToString();
    }

    public class ColumnCondition : Condition
    {
        internal RuleOperator op;
        internal float arg;
        internal string colName;

        public ColumnCondition(string colName, RuleOperator op, float arg)
        {
            this.op = op;
            this.arg = arg;
            this.colName = colName;
        }

        public override bool Verify(DataRow row)
        {
            try
            {
                return ApplyOperator(float.Parse(row[colName].ToString()), op, arg);
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return colName + " " + OperatorToString(op) + " " + arg.ToString();
        }
    }

    public class MatchColInSetCondition : Condition
    {
        internal string[] set;
        internal string colName;

        public MatchColInSetCondition(string colName, string[] set)
        {
            this.colName = colName;
            this.set = set;
        }

        public override bool Verify(DataRow row)
        {
            if (row == null)
                return true;
            try
            {
                return set.Contains(row[colName]);
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            string constring = colName + " IN { ";
            foreach (string s in set)
                constring += s + " ";
            return constring + "}";
        }
    }

    public class TotalCondition : Condition
    {
        private Dictionary<string, float> lookup;
        private string userCol;
        private string totalCol;
        private RuleOperator op;
        private float arg;

        public TotalCondition(string userCol, string totalCol, RuleOperator op, float arg)
        {
            this.userCol = userCol;
            this.totalCol = totalCol;
            this.op = op;
            this.arg = arg;
            this.lookup = new Dictionary<string, float>();
        }

        public override bool Verify(DataRow row)
        {
            if (row == null)
            {
                lookup.Clear();
                return false;
            }

            string name = (string)row[userCol];
            if (lookup.ContainsKey(name)){
                float tmp = float.Parse(row[totalCol].ToString());
                lookup[name] += tmp;
            }
            else
                lookup.Add(name, 0);

            return ApplyOperator(lookup[name], op, arg);
        }

        public override string ToString()
        {
            return "USER-TOTAL " + totalCol + " " + OperatorToString(op) + " " + arg.ToString();
        }
    }

    public class OrCondition : Condition
    {
        Condition con1;
        Condition con2;

        public OrCondition(Condition a, Condition b)
        {
            con1 = a;
            con2 = b;
        }

        public override bool Verify(DataRow row)
        {
            return (con1.Verify(row) || con2.Verify(row));
        }

        public override string ToString()
        {
            return con1.ToString() + " OR " + con2.ToString();
        }
    }

    public class AndCondition : Condition
    {
        Condition con1;
        Condition con2;

        public AndCondition(Condition a, Condition b)
        {
            con1 = a;
            con2 = b;
        }

        public override bool Verify(DataRow row)
        {
            return (con1.Verify(row) && con2.Verify(row));
        }

        public override string ToString()
        {
            return con1.ToString() + " AND " + con2.ToString();
        }
    }

    public class XorCondition : Condition
    {
        Condition con1;
        Condition con2;

        public XorCondition(Condition a, Condition b)
        {
            con1 = a;
            con2 = b;
        }

        public override bool Verify(DataRow row)
        {
            return (con1.Verify(row) ^ con2.Verify(row));
        }

        public override string ToString()
        {
            return con1.ToString() + " XOR " + con2.ToString();
        }
    }

    public class NegCondition : Condition
    {
        Condition con;

        public NegCondition(Condition con)
        {
            this.con = con;
        }

        public override bool Verify(DataRow row)
        {
            return !con.Verify(row);
        }

        public override string ToString()
        {
            return "NOT " + con.ToString();
        }
    }

    public class PlaceholderCondition : Condition
    {
        string placehold;

        public PlaceholderCondition(string placehold)
        {
            this.placehold = placehold;
        }

        public override bool Verify(DataRow row)
        {
            return true;
        }

        public override string ToString()
        {
            return placehold;
        }
    }

#endregion conditions

#region actions

    public delegate void ActionDel(object arg1, object arg2);

    public abstract class Action
    {
        public abstract void Act(DataRow row, Rule violated);
        public abstract override string ToString();
    }

    public class CancelAction : Action
    {
        ActionDel kill;

        public CancelAction(ActionDel killDel)
        {
            kill = killDel;
        }

        public override void Act(DataRow row, Rule violated)
        {
            kill(row["SESSION_ID"],row["SESSION_SPID"]);
        }

        public override string ToString()
        {
            return "KILL";
        }
    }

    public class NotifyAction : Action
    {
        private string[] emails;

        public NotifyAction(string emailList)
        {
            if (!ParseEmails(emailList))
                throw new ArgumentException("One or more emails is not valid");
        }

        private bool ParseEmails(string emails)
        {
            char[] breaks = { ',', ';',' ', '{', '}' };
            this.emails = emails.Split(breaks,StringSplitOptions.RemoveEmptyEntries);
         
            System.Text.RegularExpressions.Regex r = 
            new System.Text.RegularExpressions.Regex(@"^[\w-]+@([\w-]+\.)+[\w-]+$");

            for (int c = 0; c < emails.Length; c++)
            {
                this.emails[c] = this.emails[c].Trim();
                if(!r.IsMatch(this.emails[c]))
                    return false;
            }
            return true;
        }

        public override void Act(DataRow row, Rule violated)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string action = "NOTIFY { ";
            foreach (string s in emails)
                action += s + " ";
            return action+"}";
        }
    }

    public class AlertAction : Action
    {
        ActionDel addAlert;

        public AlertAction(ActionDel addAlert)
        {
            this.addAlert = addAlert;
        }

        public override void Act(DataRow row, Rule violated)
        {
            addAlert(row, violated);
        }

        public override string ToString()
        {
            return "ALERT";
        }
    }

#endregion

    public class Rule
    {
        internal Condition condition;
        internal Action[] actions;
        internal int priority;
        private string myString="";


        public Rule(Condition condition, Action[] actions)
        {
            this.condition = condition;
            this.actions = actions;
            priority = 1;
        }

        public virtual void Process(DataRow row)
        {
            if (condition.Verify(row))
                foreach (Action a in actions)
                    try
                    {
                        a.Act(row, this);
                    }
                    catch { }
        }

        public void SetPriority(int newPriority)
        {
            priority = newPriority;
        }

        public static string PriorityToString(int priority)
        {
            switch(priority){
                case 0:
                    return "HIGH";
                case 1:
                    return "MEDIUM";
                default:
                    return "LOW";
            }
        }

        public static int StringToPriority(string priority)
        {
            switch (priority)
            {
                case "HIGH":
                    return 0;
                case "MEDIUM":
                    return 1;
                default:
                    return 2;
            }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(myString))
            {
                myString = "IF " + condition.ToString() + " THEN ";
                for (int c = 0; c < actions.Length; c++)
                    myString += actions[c].ToString() + (c != actions.Length - 1 ? " AND " : "");
            }
            return myString;
        }
    }

    public delegate DataTable QueryToData(string query);

    public class WhereRule : Rule
    {

        internal string dataQuery = "select * from $System.DISCOVER_SESSIONS WHERE ";
        private QueryToData getData;
        private string myString = "";
        private bool canProcess = true;

        public WhereRule(QueryToData getData, string whereClause, Action[] actions)
            : base(new PlaceholderCondition(whereClause), actions)
        {
            this.getData = getData;
            dataQuery += whereClause;
        }

        public override void Process(DataRow row)
        {   //null resets rule to be processed
            //this way rule is processed once per scan, not once per row
            if (row == null)
            {
                canProcess = true;
                return;
            }
            if (canProcess)
            {
                DataTable theData = getData(dataQuery);

                foreach (DataRow datarow in theData.Rows)
                    foreach (Action action in actions)
                        if(datarow != null)
                            action.Act(datarow, this);
                canProcess = false;
            }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(myString))
            {
                myString = "WHERE " + condition.ToString() + " THEN ";
                for (int c = 0; c < actions.Length; c++)
                    myString += actions[c].ToString() + (c != actions.Length - 1 ? " AND " : "");
            }
            return myString;
        }
    }

}
