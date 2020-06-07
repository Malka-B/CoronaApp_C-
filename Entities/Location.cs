using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Location:IComparable
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public int CompareTo(object obj)
        {
            return this.StartDate.CompareTo((obj as Location).StartDate);
        }
    }
}
