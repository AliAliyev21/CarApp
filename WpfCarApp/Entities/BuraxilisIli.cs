using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarApp.Entities
{
    public class BuraxilisIli
    {
        public int BuraxilisIliID { get; set; }
        public string BuraxilisIliName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public override string ToString()
        {
            return BuraxilisIliName;
        }
    }
}
