using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarApp.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}
