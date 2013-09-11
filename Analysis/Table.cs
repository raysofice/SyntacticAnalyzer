using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class Table
    {
        public Dictionary<TableIndex, TableItem> dic { get; set; }

        public Table()
        {
            dic=new Dictionary<TableIndex,TableItem>();
        }

        public void add(TableIndex i, TableItem a)
        {
            if (dic.ContainsKey(i))
            {
                if (dic[i].Equals(a)) return;
                else throw new Exception("写入分析表冲突，该文法不是LR(1)文法");
            }
            else
            {
                dic.Add(i, a);
            }
        }

        public TableItem GetAction(TableIndex i)
        {
            if (this.dic.ContainsKey(i))
            {
                return this.dic[i];
            }
            else
            {
                throw new Exception("查询分析表结果为ERROR");
            }
        }
    }
}
