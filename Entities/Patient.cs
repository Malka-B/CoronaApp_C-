using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Patient
    {
        public Patient()
        {
            LocationList = new HashSet<Location>();
        }
        public int Id { get; set; }
        public ICollection<Location> LocationList { get; set; }
    }
}
