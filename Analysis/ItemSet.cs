using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class ItemSet:HashSet<Item>
    {
        public bool AddItem(Item item)
        {
            return this.Add(item);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var other = obj as ItemSet;
            if (this.Count != other.Count)
            {
                return false;
            }
            foreach (Item i1 in this)
            {
                bool f = false;
                foreach (Item i2 in other)
                {
                    if (i1.Index == i2.Index && i1.Production.Equals(i2.Production) && i1.Symbol.Equals(i2.Symbol))
                    {
                        f = true;
                        break;
                    }
                }
                if (!f)
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (Item item in this)
            {
                hashCode += item.GetHashCode();
            }
            return hashCode;
        }
    }
}
