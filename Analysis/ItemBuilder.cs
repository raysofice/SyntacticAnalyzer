using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public static class ItemBuilder
    {
        public static void Closure( this ItemSet itemset,cfg cfg, FirstSet first)
        {
            HashSet<Production> productions = cfg.Productions;
            bool changed;
            do
            {
                changed = false;
                char end = System.Configuration.ConfigurationManager.AppSettings["End"][0];
                for (int i = 0; i < itemset.Count; ++i)
                {
                    Item item = itemset.ElementAt(i);
                    int index = item.Index;
                    string right = item.Production.Right;
                    if (index >= right.Length || !cfg.isVn(right[index]))
                    {
                        continue;
                    }
                    foreach (Production production in productions)
                    {
                        if (production.Left != right[index])
                        {
                            continue;
                        }
                        int length = right.Length;
                        if (index + 1 == right.Length)
                        {
                            Item newItem = new Item(production, 0,item.Symbol);
                            changed |= itemset.AddItem(newItem);
                            continue;
                        }
                        
                        if (index + 1 < right.Length)
                        {
                            char empty = System.Configuration.ConfigurationManager.AppSettings["Empty"][0];
                            HashSet<char> symbols = first.GetFirst(right[index + 1]);
                            foreach (char c in symbols)
                            {
                                if (c == empty)
                                {
                                    Item newItem = new Item(production, 0, item.Symbol);
                                    changed |= itemset.Add(newItem);
                                }
                                else
                                {
                                    Item newItem = new Item(production, 0, c);
                                    changed |= itemset.Add(newItem);
                                }                                
                            }
                        }
                    }
                }
            } while (changed);
        }

        public static ItemSet Go(this ItemSet itemset,char c)
        {
            ItemSet set=new ItemSet();
            foreach (Item i in itemset)
            {
                if (i.Index < i.Production.Right.Length && i.Production.Right[i.Index] == c)
                {
                    Item item = new Item(i.Production, i.Index + 1, i.Symbol);
                    set.Add(item);
                }
            }
            return set;
        }
    }
}
