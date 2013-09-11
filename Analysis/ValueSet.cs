using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class ValueSet<T>:HashSet<T>
    {
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var other = obj as ValueSet<T>;
            if (this.Count != other.Count)
            {
                return false;
            }
            foreach (T t in this)
            {
                if (!other.Contains(t))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (T t in this)
            {
                hashCode += t.GetHashCode();
            }
            return hashCode;
        }
    }
}
