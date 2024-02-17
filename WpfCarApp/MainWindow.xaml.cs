using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCarApp.DataAccess;
using WpfCarApp.Entities;

namespace WpfCarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private MyContext _context = new MyContext();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private Brand _selectedBrand;
        public Brand SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                _selectedBrand = value;
                OnPropertyChanged("SelectedBrand");
            }
        }

        private NewOrOld _selectedNewOrOld;
        public NewOrOld SelectedNewOrOld
        {
            get { return _selectedNewOrOld; }
            set
            {
                _selectedNewOrOld = value;
                OnPropertyChanged("SelectedNewOrOld");
            }
        }

        private BanNovu _selectedBanNovu;
        public BanNovu SelectedBanNovu
        {
            get { return _selectedBanNovu; }
            set
            {
                _selectedBanNovu = value;
                OnPropertyChanged("SelectedBanNovu");
            }
        }

        private Yurus _selectedYurus;
        public Yurus SelectedYurus
        {
            get { return _selectedYurus; }
            set
            {
                _selectedYurus = value;
                OnPropertyChanged("SelectedYurus");
            }
        }

        private BuraxilisIli _selectedBuraxilisIli;
        public BuraxilisIli SelectedBuraxilisIli
        {
            get { return _selectedBuraxilisIli; }
            set
            {
                _selectedBuraxilisIli = value;
                OnPropertyChanged("SelectedBuraxilisIli");
            }
        }

        private Entities.Color _selectedColor;
        public Entities.Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }

        private Price _selectedPrice;
        public Price SelectedPrice
        {
            get { return _selectedPrice; }
            set
            {
                _selectedPrice = value;
                OnPropertyChanged("SelectedPrice");
            }
        }

        private PetrolType _selectedPetrolType;
        public PetrolType SelectedPetrolType
        {
            get { return _selectedPetrolType; }
            set
            {
                _selectedPetrolType = value;
                OnPropertyChanged("SelectedPetrolType");
            }
        }

        public ObservableCollection<Brand> Brands { get; set; } = new ObservableCollection<Brand>();
        public ObservableCollection<NewOrOld> NewOrOlds { get; set; } = new ObservableCollection<NewOrOld>();
        public ObservableCollection<BanNovu> BanNovus { get; set; } = new ObservableCollection<BanNovu>();
        public ObservableCollection<Yurus> Yuruses { get; set; } = new ObservableCollection<Yurus>();
        public ObservableCollection<BuraxilisIli> BuraxilisIlis { get; set; } = new ObservableCollection<BuraxilisIli>();
        public ObservableCollection<Entities.Color> Colors { get; set; } = new ObservableCollection<Entities.Color>();
        public ObservableCollection<Price> Prices { get; set; } = new ObservableCollection<Price>();
        public ObservableCollection<PetrolType> PetrolTypes { get; set; } = new ObservableCollection<PetrolType>();

        public MainWindow()
        {
            InitializeComponent();

            _context.Database.CreateIfNotExists();

            brandInfo.SelectedIndex = 1;
            petrolInfo.SelectedIndex = 0;
            colorInfo.SelectedIndex = 0;
            banInfo.SelectedIndex = 0;
            buraxilisInfo.SelectedIndex = 0;
            yurusInfo.SelectedIndex = 0;
            newOrOldInfo.SelectedIndex = 0;

            this.DataContext = this;

            LoadBrand();

            LoadBanNovu();

            LoadBuraxilisIli();

            LoadColor();

            LoadNewOrOld();

            LoadPetrolType();

            LoadYurus();

            LoadPrice();
        }

        private void LoadPrice()
        {
            if (_context.Prices.Count() == 0)
            {
                AddPrice();
            }

            foreach (var price in _context.Prices)
            {
                Prices.Add(price);
            }
        }

        private void AddPrice()
        {
            const int min = 0;
            const int max = 500000;  

            for (int i = min; i <= max; i += 5000) 
            {
                Prices.Add(new Price { PriceID = i });
            }
        }

        private void LoadYurus()
        {
            if (_context.Yuruss.Count() == 0)
            {
                AddYurus();
            }

            foreach (var yurus in _context.Yuruss)
            {
                Yuruses.Add(yurus);
            }


        }

        private void AddYurus()
        {
            const int min = 0;
            const int max = 500000;

            Yuruses.Clear();
            for (int i = min; i <= max; i += 10000)
            {
                Yuruses.Add(new Yurus { YurusID = i });
            }
        }

        private void LoadPetrolType()
        {
            if (_context.PetrolTypes.Count() == 0)
            {
                AddPetrolType();
            }

            foreach (var petrolType in _context.PetrolTypes)
            {
                PetrolTypes.Add(petrolType);
            }
        }

        private void AddPetrolType()
        {
            var petrolTypeList = new List<PetrolType>
            {
                new PetrolType { PetrolTypeID = 1, PetrolTypeName = "Benzin", Cars = _context.Cars.ToList() },
                new PetrolType { PetrolTypeID = 2, PetrolTypeName = "Dizel", Cars = _context.Cars.ToList() },
                new PetrolType { PetrolTypeID = 3, PetrolTypeName = "Hybrid", Cars = _context.Cars.ToList() },
                new PetrolType { PetrolTypeID = 4, PetrolTypeName = "Qaz", Cars = _context.Cars.ToList() },
            };

            _context.PetrolTypes.AddRange(petrolTypeList);
            _context.SaveChanges();
        }

        private void LoadNewOrOld()
        {
            if (_context.NewsOrOlds.Count() == 0)
            {
                AddNewOrOld();
            }

            foreach (var item in _context.NewsOrOlds)
            {
                NewOrOlds.Add(item);
            }
        }

        private void AddNewOrOld()
        {
            var newOrOldList = new List<NewOrOld>
            {
                new NewOrOld { NewOrOldID = 1, Status = "New" },
                new NewOrOld { NewOrOldID = 2, Status = "Used" }
            };

            _context.NewsOrOlds.AddRange(newOrOldList);
            _context.SaveChanges();
        }

        private void LoadColor()
        {
            if(_context.Colors.Count()==0)
            {
                AddColors();
            }

            foreach(var color in _context.Colors)
            {
                Colors.Add(color);
            }
        }

        private void AddColors()
        {
            var listColor = new List<Entities.Color>
            {
                new Entities.Color{ColorID=1,ColorName="White"},
                new Entities.Color{ColorID=2,ColorName="Black"},
                new Entities.Color{ColorID=3,ColorName="Blue"},
            };

            _context.Colors.AddRange(listColor);
            _context.SaveChanges();
        }

        private void LoadBuraxilisIli()
        {
            if(_context.BuraxilisIlis.Count()==0)
            {
                AddBuraxilisIli();
            }

            foreach (var buraxilisIli in _context.BuraxilisIlis)
            {
                BuraxilisIlis.Add(buraxilisIli);
            }

            SelectedBuraxilisIli = BuraxilisIlis.FirstOrDefault();
        }

        private void AddBuraxilisIli()
        {
            const int min = 2010;
            const int max = 2024;

            for (int i = min; i <= max; i++)
            {
                BuraxilisIlis.Add(new BuraxilisIli { BuraxilisIliID = i });
            }
        }

        private void LoadBanNovu()
        {
            if(_context.BanNovus.Count()==0)
            {
                AddBanNovu();
            }

            foreach (var banNovu in _context.BanNovus)
            {
                BanNovus.Add(banNovu);
            }
        }

        private void AddBanNovu()
        {
            var listBanNovu = new List<BanNovu>
            {
                new BanNovu {BanNovuID=1,BanNovuName="Sedan"},
                new BanNovu {BanNovuID=2,BanNovuName="Cip"},
                new BanNovu {BanNovuID=3,BanNovuName="Hatchback"},
            };

            _context.BanNovus.AddRange(listBanNovu);
            _context.SaveChanges();
        }

        private void LoadBrand()
        {
            if (_context.Brands.Count() == 0)
            {
                AddBrand();
            }

            foreach (var brand in _context.Brands)
            {
                Brands.Add(brand);
            }
        }

        private void AddBrand()
        {
            var listBrand = new List<Brand>
            {
                new Brand { BrandID=1,BrandName="Mercedes E-63s competition"},
                new Brand { BrandID=2,BrandName="BMW M5cs F90 "},
                new Brand { BrandID=3,BrandName="Mercedes C-300"},
                new Brand { BrandID=4,BrandName="BMW M3"},
                new Brand { BrandID=5,BrandName="Porche Taycan"},
                new Brand { BrandID=6,BrandName="Hyunndai Elantra"},
                new Brand { BrandID=7,BrandName="Kia Optima"},
                new Brand { BrandID=8,BrandName="Opel Astara"},
                new Brand { BrandID=9,BrandName="Chevrolet Cruze"},
                new Brand { BrandID=10,BrandName="Audi A7 sportback"}
            };

            _context.Brands.AddRange(listBrand);
            _context.SaveChanges();
        }

        private void CarInfo_Click(object sender, RoutedEventArgs e)
        {
            brandlbl.Content = SelectedBrand?.BrandName;
            petrollbl.Content = SelectedPetrolType?.PetrolTypeName;
            colorlbl.Content = SelectedColor?.ColorName;
            banlbl.Content = SelectedBanNovu?.BanNovuName;
            buraxilislbl.Content = SelectedBuraxilisIli?.BuraxilisIliID.ToString();
            newoldlbl.Content = SelectedNewOrOld?.Status;
            yuruslbl.Content = SelectedYurus?.YurusID.ToString();
            priceminlbl.Content = minPriceTextBox.Text;
            pricemaxlbl.Content = maxPriceTextBox.Text;
        }
    }
}
