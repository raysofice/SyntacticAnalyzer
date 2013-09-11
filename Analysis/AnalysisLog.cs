using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class AnalysisLog
    {
        public int Index { get; set; }
        public string StatusStack { get; set; }
        public string CharStack { get; set; }
        public string Remain { get; set; }
        public string Action { get; set; }
        public string GoTo{get;set;}        

        public AnalysisLog(int index, string remain, string statusStack, string charSatck, string action,string Goto)
        {
            this.Index = index;
            this.Remain = remain;
            this.StatusStack = statusStack;
            this.CharStack = charSatck;
            this.Action = action;
            this.GoTo=Goto;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Index,StatusStack, CharStack, Remain ,Action,GoTo );
        }
    }
}
