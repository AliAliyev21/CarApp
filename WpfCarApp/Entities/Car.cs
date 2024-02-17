using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarApp.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int NewOrOldID { get; set; }
        public int BanNovuID { get; set; }
        public int YurusID { get; set; }
        public int BuraxilisIliID { get; set; }
        public int ColorID { get; set; }
        public int PriceID { get; set; }
        public int PetrolTypeID { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual NewOrOld NewOrOld { get; set; }
        public virtual BanNovu BanNovu { get; set; }
        public virtual Yurus Yurus { get; set; }
        public virtual BuraxilisIli BuraxilisIli { get; set; }
        public virtual Color Color { get; set; }
        public virtual Price Price { get; set; }
        public virtual PetrolType PetrolType { get; set; }

        public override string ToString()
        {
            return $"{Brand} - {Color} - {PetrolType} - {Price}";
        }
    }
}
