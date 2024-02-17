using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarApp.Entities
{
    public class NewOrOld
    {
        public int NewOrOldID { get; set; }
        public string Status { get; set; } // 'New' or 'Old'
        public virtual ICollection<Car> Cars { get; set; }

        public override string ToString()
        {
            return Status;
        }
    }
}
