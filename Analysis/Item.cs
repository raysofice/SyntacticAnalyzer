using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class Item
    {
        public Production Production { get; set; }
        public int Index { get; set; }
        public Char Symbol { get; set; }

        public Item() { }

        public Item(Production p, int i, Char s)
        {
            Production = p;
            Index = i;
            if (p.Right == System.Configuration.ConfigurationManager.AppSettings["Empty"][0].ToString())
            {
                Production.Right = "";
                Index = 0;
            }
            Symbol = s;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var other = obj as Item;
            return this.Production.Equals(other.Production)
                 && this.Index == other.Index
                 && this.Symbol.Equals(other.Symbol);
        }
        public override int GetHashCode()
        {
            return this.Production.GetHashCode() +
                this.Index.GetHashCode() +
                this.Symbol.GetHashCode();
        }

        public override string ToString()
        {
            string s0 = Production.Left.ToString();
            string s1 = Production.Right.Substring(0,Index);
            string s2 = Production.Right.Substring(Index);
            if (s2 == "ε")
                s2 = "";
            string s3 = String.Empty;
            s3 = Symbol.ToString();
            return string.Format("{0}→{1}·{2}，{3}", s0, s1, s2, s3);
        }
    }
}
