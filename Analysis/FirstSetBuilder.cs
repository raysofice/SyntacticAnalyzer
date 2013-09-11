using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class FirstSetBuilder
    {
        public FirstSet FirstSets { get; set; }
        public cfg cfg { get; set; }
        public Boolean Changed { get; set; }
        public char Empty { get; set; }

        public FirstSetBuilder(cfg cfg)
        {
            FirstSets = new FirstSet();
            this.cfg = cfg;
            Empty=System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
            foreach (char c in cfg.Vn)
            {
                FirstSets.Add(c, new HashSet<char>());
            }
            Build();
        }

        public void Build()
        {
            do
            {
                Changed = false;
                foreach (Production pro in cfg.Productions)
                {
                    AnalyseProduction(pro);
                }
            } while (Changed);
        }

        public void AnalyseProduction(Production p)
        {
            char key = p.Left;
            char fchar = p.Right[0];
            if (cfg.isVn(fchar))
            {
                fchar_Vn(p);
            }
            else
            {
                Changed |= FirstSets[key].Add(fchar);
            }
        }

        public void fchar_Vn(Production p)
        {
            char key = p.Left;
            char fchar = p.Right[0];
            foreach (char c in FirstSets[fchar])
            {
                if (c != Empty)
                {
                    Changed |= FirstSets[key].Add(c);
                }
            }
            int i;
            for (i = 0; i < p.Right.Length; ++i)
            {
                char ch = p.Right[i];
                if (cfg.isVn(ch) && FirstSets[fchar].Contains(Empty))
                {
                    foreach (char c in FirstSets[ch])
                    {
                        if (c != Empty)
                        {
                            Changed |= FirstSets[key].Add(c);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (i == p.Right.Length)
            {
                Changed |= FirstSets[key].Add(Empty);
            }
        }
    }
}
