using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class NowyProduktViewModel : JedenViewModel<Produkty>
    {
        #region Konstruktor
        public NowyProduktViewModel() : base("Produkty")
        {
            item = new Produkty();
        }
        #endregion
        #region Dane
        public DateTime? KiedyDodal
        {
            get
            {
                return item.KiedyDodal;
            }
            set
            {
                if (item.KiedyDodal != value)
                {
                    item.KiedyDodal = value;
                    OnPropertyChanged(() => KiedyDodal);
                }
            }
        }
        public int Idproduktu
        {
            get
            {
                return item.Idproduktu;
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }
        public string OpisProduktu
        {
            get
            {
                return item.OpisProduktu;
            }
            set
            {
                if (item.OpisProduktu != value)
                {
                    item.OpisProduktu = value;
                    OnPropertyChanged(() => OpisProduktu);
                }
            }
        }
        public int? Idkategorii
        {
            get
            {
                return item.Idkategorii;
            }
            set
            {
                if (item.Idkategorii != value)
                {
                    item.Idkategorii = value;
                    OnPropertyChanged(() => Idkategorii);
                }
            }
        }
        public int? IloscNaStanie
        {
            get
            {
                return item.IloscNaStanie;
            }
            set
            {
                if (item.IloscNaStanie != value)
                {
                    item.IloscNaStanie = value;
                    OnPropertyChanged(() => IloscNaStanie);
                }
            }
        }
        public string JednostkaMiary
        {
            get
            {
                return item.JednostkaMiary;
            }
            set
            {
                if (item.JednostkaMiary != value)
                {
                    item.JednostkaMiary = value;
                    OnPropertyChanged(() => JednostkaMiary);
                }
            }
        }
        public string Producent
        {
            get
            {
                return item.Producent;
            }
            set
            {
                if (item.Producent != value)
                {
                    item.Producent = value;
                    OnPropertyChanged(() => Producent);
                }
            }
        }
        public IQueryable<KeyAndValue> KategoriaComboBoxItems
        {
            get
            {
                return (
                    from Kategorie in projektEntities.Kategories
                    select new KeyAndValue
                    {
                        Key = Kategorie.Idkategorii,
                        Value = Kategorie.NazwaKategorii,
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
