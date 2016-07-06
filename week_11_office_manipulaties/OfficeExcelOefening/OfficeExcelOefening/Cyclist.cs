using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeExcelOefening
{
    public class Cyclist : ModelBaseClass, IComparable<Cyclist>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Sponsor { get; set; }
        public String Nationality { get; set; }
        public int CompareTo(Cyclist other)
        {
            if (this.LastName == other.LastName)
                return this.FirstName.CompareTo(other.FirstName);
            else
                return this.LastName.CompareTo(other.LastName);
        }

        public override bool Equals(object obj)
        {
            Cyclist other = obj as Cyclist;
            if (null == other) return false;
            return this.ID.Equals(other.ID);
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
