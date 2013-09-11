using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    public class TableIndex
    {
        public int Status { get; set; }
        public char Input { get; set; }

        public TableIndex(int status, char input)
        {
            this.Status = status;
            this.Input = input;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            var other = obj as TableIndex;
            return this.Status == other.Status && this.Input == other.Input;
        }

        public override int GetHashCode()
        {
            return Status.GetHashCode() + Input.GetHashCode();
        }
    }
}
