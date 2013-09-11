using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class TableItem
    {
        public char ActionType { get; set; }
        public int Detail { get; set; }

        public TableItem(char actionType, int detail)
        {
            this.ActionType = actionType;
            this.Detail = detail;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var other = obj as TableItem;
            return this.ActionType == other.ActionType && this.Detail == other.Detail;
        }
        public override int GetHashCode()
        {
            return ActionType.GetHashCode() + Detail.GetHashCode();
        }
    }
}
