using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class Analysis
    {
        public cfg CFG { get; set; }
        public Dictionary<int, Char> Va { get; set; }
        public Dictionary<int, Char> Vg { get; set; }
        public FirstSet FirstSets { get; set; }
        public Dictionary<ItemSet, int> ItemSetMap { get; set; }
        public Dictionary<int, ItemSet> _ItemSetMap { get; set; }
        public Table Table { get; set; }
        public List<AnalysisLog> AnalysisLogs { get; set; }
        private Stack<int> StatusStack;
        private Stack<Char> CharStack;

        public Analysis(string[] Input)
        {
            CFG = new cfg(Input);
            FirstSetBuilder first = new FirstSetBuilder(CFG);
            this.FirstSets = first.FirstSets;
            this.Va = new Dictionary<int, char>() { };
            this.Vg = new Dictionary<int, char>() { };
            char empty = System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
            char end = System.Configuration.ConfigurationManager.AppSettings["End"][0];
            int k = 0;
            for (int i = 0; i < CFG.Vt.Count; ++i)
            {
                char c = CFG.Vt.ElementAt(i);
                if (c != empty)
                {
                    Va.Add(k++, c);
                }
            }
            Va.Add(k++, end);
            for (int i = 0; i < CFG.Vn.Count; ++i)
            {
                char c = CFG.Vn.ElementAt(i);
                Vg.Add(i, c);
            }
            TableBuilder tableBuilder = new TableBuilder(CFG, FirstSets);
            this.Table = tableBuilder.Table;
            this.ItemSetMap = tableBuilder.ItemSetMap;
            this._ItemSetMap = tableBuilder._ItemSetMap;
        }

        public bool Process(string sentence)
        {
            foreach (char c in sentence)
            {
                if (CFG.isVn(c))
                {
                    throw new Exception("不能含有终结符");
                }
            }
            this.AnalysisLogs = new List<AnalysisLog>();
            AnalysisLog log = null;
            char endChar = System.Configuration.ConfigurationManager.AppSettings["End"][0];
            sentence += endChar;
            StatusStack = new Stack<int>();
            StatusStack.Push(0);
            CharStack = new Stack<char>();
            CharStack.Push(endChar);
            int point = 0;
            int index = 0;
            do
            {
                try
                {
                    GoNext(sentence, ref log, ref point, ref index);
                }
                catch
                {
                    log.Action = "ERR";
                    AnalysisLogs.Add(log);
                    return false;
                }
                AnalysisLogs.Add(log);
            } while (log.Action != "acc");
            return true;
        }

        private void GoNext(string sentence, ref AnalysisLog log, ref int point, ref int index)
        {
            TableItem action;
            char input = sentence[point];
            log = new AnalysisLog(++index,sentence.Substring(point), StackContent(StatusStack), StackContent(CharStack), string.Empty,string.Empty);
            action = Table.GetAction(new TableIndex(StatusStack.Peek(),input));
            if (action.ActionType == 'A')
            {
                A(log);
            }
            else if (action.ActionType == 'S')
            {
                point = S(sentence, log, point, action);
            }
            else if (action.ActionType == 'R')
            {
                R(log, action);
            }
        }

        private void A(AnalysisLog log)
        {
            log.Action = "acc";
            log.GoTo = "";
        }

        private int S(string sentence, AnalysisLog log, int point, TableItem action)
        {
            log.Action = "S" + action.Detail;
            log.GoTo = "";
            CharStack.Push(sentence[point++]);
            StatusStack.Push(action.Detail);
            return point;
        }

        private void R(AnalysisLog log, TableItem action)
        {
            log.Action = "R" + action.Detail;
            Production production = CFG._ProductionsMap[action.Detail];
            char emptyChar = System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
            int num = production.Right == emptyChar.ToString() ? 0 : production.Right.Length;
            for (int i = 0; i < num; i++)
            {
                CharStack.Pop();
                StatusStack.Pop();
            }
            CharStack.Push(production.Left);
            action = Table.GetAction(new TableIndex(StatusStack.Peek(), production.Left));
            StatusStack.Push(action.Detail);
            log.GoTo = action.Detail.ToString();
        }

        private string StackContent(Stack<char> stack)
        {
            string res = string.Empty;
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                res += stack.ElementAt(i); ;
            }
            return res;
        }

        private string StackContent(Stack<int> stack)
        {
            string res = string.Empty;
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                res += stack.ElementAt(i); ;
            }
            return res;
        }


    }
}
