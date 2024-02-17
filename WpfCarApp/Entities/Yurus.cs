using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarApp.Entities
{
    public class Yurus
    {
        public int YurusID { get; set; }
        public int MinYurus { get; set; }
        public int MaxYurus { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public override string ToString()
        {
            return $"Min: {MinYurus}, Max: {MaxYurus}";
        }
    }
}
