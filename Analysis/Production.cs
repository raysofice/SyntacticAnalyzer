using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class Production
    {
        public char Left { get; set; }
        public string Right { get; set; }

        public Production() { }

        public Production(char Left, string Right)
        {
            this.Left = Left;
            this.Right = Right;
        }

        public override int GetHashCode()
        {
            return this.Left.GetHashCode() + this.Right.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}→{1}",Left,Right);
        }
    }
}
