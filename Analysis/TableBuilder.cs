using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class TableBuilder
    {
        public cfg CFG{get;set;}
        public FirstSet First { get; private set; }
        public Table Table { get; private set; }
        public Dictionary<ItemSet, int> ItemSetMap { get; private set; }
        public Dictionary<int,ItemSet> _ItemSetMap { get; private set; }
        
        private ItemSet FirstItem
        {
            get
            {
                char startChar = System.Configuration.ConfigurationManager.AppSettings["Start"][0];
                char endChar = System.Configuration.ConfigurationManager.AppSettings["End"][0];
                HashSet<Char> Symbol= new HashSet<char>();
                Item start = new Item(new Production(startChar, CFG.Start.ToString()), 0,endChar);
                ItemSet itemSet = new ItemSet();
                itemSet.Add(start);
                return itemSet;
            }
        }

        public TableBuilder(cfg cfg, FirstSet first)
        {
            this.CFG = cfg;
            this.First = first;
            Build();
        }

        private void Build()
        {
            Table = new Table();
            ItemSetMap = new Dictionary<ItemSet, int>();
            _ItemSetMap = new Dictionary<int, ItemSet>();

            ItemSet itemSet = FirstItem;
            itemSet.Closure(CFG, First);
            ItemSetMap.Add(itemSet, ItemSetMap.Count);
            _ItemSetMap.Add(_ItemSetMap.Count, itemSet);
            int status = 0;
            while (status < ItemSetMap.Count)
            {
                itemSet = ItemSetMap.Keys.ElementAt(status);
                foreach (Item item in itemSet)
                {
                    if (item.Index < item.Production.Right.Length && item.Production.Right!=System.Configuration.ConfigurationManager.AppSettings["Empty"])
                    {
                        UnFinished(itemSet, status, item);
                    }
                    else
                    {
                        Finished(status, item);
                    }
                }
                status++;
            }

        }

        private void Finished(int status, Item item)
        {
            TableIndex index = new TableIndex(status, item.Symbol);
            if (item.Production.Right == string.Empty)
            {
                Production pro = item.Production;
                pro.Right = System.Configuration.ConfigurationManager.AppSettings["Empty"][0].ToString();
                int i;
                for (i = 0; i < CFG.ProductionsMap.Count; i++)
                {
                    if (CFG.ProductionsMap.Keys.ElementAt(i).Equals(pro))
                    {
                        break;
                    }
                }
                Table.add(index, new TableItem('R', CFG.ProductionsMap.Values.ElementAt(i)));
            }
            else if (item.Index>=1 && item.Production.Right[item.Index - 1] == CFG.Start)
            {
                Table.add(index, new TableItem('A', -1));
            }
            else
            {
                Table.add(index, new TableItem('R', CFG.ProductionsMap[item.Production]));
            }
        }

        private void UnFinished(ItemSet itemSet, int status, Item item)
        {
            char nextChar = item.Production.Right[item.Index];
            if (nextChar == System.Configuration.ConfigurationManager.AppSettings["Empty"][0])
            {
                return;
            }
            ItemSet nextSet = itemSet.Go(nextChar);
            nextSet.Closure(CFG, First);
            if (!InItemSetMap(nextSet))
            {
                ItemSetMap.Add(nextSet, ItemSetMap.Count);
                _ItemSetMap.Add(_ItemSetMap.Count, nextSet);
            }
            if (CFG.isVn(nextChar))
            {
                Table.add(new TableIndex(status, nextChar), new TableItem('G', ItemSetMap[nextSet]));
            }
            else
            {
                Table.add(new TableIndex(status, nextChar), new TableItem('S', ItemSetMap[nextSet]));
            }
        }

        private bool InItemSetMap(ItemSet iset)
        {
            int status = 0;
            bool flag = false;
            while (status < ItemSetMap.Count)
            {
               if(iset.Equals(ItemSetMap.Keys.ElementAt(status)))
               {
                   flag=true;
                   break;
               }                
               status++;
            }
            return flag;
        }
    }
}
