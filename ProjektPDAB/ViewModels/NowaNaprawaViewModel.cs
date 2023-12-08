using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class NowaNaprawaViewModel : JedenViewModel<Naprawy>
    {
        #region Kontruktor
        public NowaNaprawaViewModel() : base("Naprawy")
        {
            item = new Naprawy();
        }
        #endregion
        #region Dane
        public int Idnaprawy { get; }
        public int? DataNaprawy
        {
            get
            {
                return item.DataNaprawy;
            }
            set
            {
                if (item.DataNaprawy != value)
                {
                    item.DataNaprawy = value;
                    OnPropertyChanged(() => DataNaprawy);
                }
            }
        }
        public int? StatusNaprawy
        {
            get
            {
                return item.StatusNaprawy;
            }
            set
            {
                if (item.StatusNaprawy != value)
                {
                    item.StatusNaprawy = value;
                    OnPropertyChanged(() => StatusNaprawy);
                }
            }
        }
        public int? Idserwisu
        {
            get
            {
                return item.Idserwisu;
            }
            set
            {
                if (item.Idserwisu != value)
                {
                    item.Idserwisu = value;
                    OnPropertyChanged(() => Idserwisu);
                }
            }
        }
        public int? Idproduktu
        {
            get
            {
                return item.Idproduktu;
            }
            set
            {
                if (item.Idproduktu != value)
                {
                    item.Idproduktu = value;
                    OnPropertyChanged(() => Idproduktu);
                }
            }
        }
        public IQueryable<KeyAndValue> SerwisComboBoxItems
        {
            get
            {
                return (
                    from Serwisy in projektEntities.Serwisies
                    select new KeyAndValue
                    {
                        Key = Serwisy.Idserwisu,
                        Value = Serwisy.NazwaSerwisu + " " + Serwisy.Adres + " " + Serwisy.Kontakt
                    }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> ProduktComboBoxItems
        {
            get
            {
                return (
                    from Produkty in projektEntities.Produkties
                    select new KeyAndValue
                    {
                        Key = Produkty.Idproduktu,
                        Value = Produkty.IdkategoriiNavigation.NazwaKategorii + " " + Produkty.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
