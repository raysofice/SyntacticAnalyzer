using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class FirstSet:Dictionary<Char,HashSet<Char>>
    {

        public FirstSet() { }

        public HashSet<Char> GetFirst(char c)
        {
            char empty = System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
            HashSet<Char> t;
            if (c >= 'A' && c <= 'Z')
            {
                if (this.ContainsKey(c))
                    t = this[c];
                else
                    t = new HashSet<Char>();
            }
            else
            {
                t = new HashSet<Char>();
                t.Add(c);
            }
            return t;
        }

    }
}
