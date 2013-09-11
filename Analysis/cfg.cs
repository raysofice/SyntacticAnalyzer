using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class cfg
    {
        public HashSet<Production> Productions { get; set; }
        public Dictionary<Production, int> ProductionsMap { get; set; }
        public Dictionary<int, Production> _ProductionsMap { get; set; }
        public HashSet<Char> Vn { get; set; }
        public HashSet<Char> Vt { get; set; }
        public char Start { get; set; }

        public cfg() 
        {
            Productions = new HashSet<Production>();
            ProductionsMap = new Dictionary<Production, int>();
            _ProductionsMap = new Dictionary<int, Production>();
            Vn = new HashSet<char>();
            Vt = new HashSet<char>();
            Start = new char();
        }

        public cfg(string[] Input)
        {
            Productions = new HashSet<Production>();
            ProductionsMap = new Dictionary<Production, int>();
            _ProductionsMap = new Dictionary<int,Production>();
            Vn = new HashSet<char>();
            Vt = new HashSet<char>();
            Start = new char();
            Build(Input);
        }

        public void Build(string[] Input)
        {
            try
            {
                Start = Input[0][0];
                foreach (string s in Input)
                {
                      if (s == string.Empty)
                      {
                          continue;
                      }
                      string[] tp = s.Split(new String[] { "→" }, StringSplitOptions.None);
                      if (tp.Length != 2)
                      {
                          throw new Exception("产生式应该有且仅有一个→");
                      }
                      if (tp[0].Length != 1 || !isVn(tp[0][0]))
                      {
                          throw new Exception("产生式左边应该是一个非终结符");
                      }
                      char left = tp[0][0];
                      char empty= System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
                      Vn.Add(left);
                      string[] right = tp[1].Split('|');
                      for (int i = 0; i < right.Count(); ++i)
                      {
                          string part = right[i];
                          foreach (char c in part)
                          {
                              if (isVn(c))
                              {
                                  Vn.Add(c);
                              }
                              else
                              {
                                  Vt.Add(c);
                              }
                          }
                          Production p = new Production(left,part);
                          if (!ProductionsMap.ContainsKey(p))
                          {
                              Productions.Add(p);
                              ProductionsMap.Add(p, ProductionsMap.Count() + 1);
                              _ProductionsMap.Add(_ProductionsMap.Count() + 1, p);
                          }
                      }
                }
            }
            catch (Exception )
            {
                throw new Exception("输入不合法\n");
            }
        }

        public bool isVn(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return true;
            return false;
        }

    }
}
