using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektPDAB.ViewModels
{
    class NowaNaprawaViewModel : JedenViewModel<Naprawy>
    {
        #region Commands
        private BaseCommand _ShowProduktyCommand;
        public ICommand ShowProduktyCommand
        {
            get
            {
                if (_ShowProduktyCommand == null)
                {
                    _ShowProduktyCommand = new BaseCommand(() => Messenger.Default.Send("ShowProdukty"));
                }
                return _ShowProduktyCommand;
            }
        }
        private BaseCommand _ShowSerwisyCommand;
        public ICommand ShowSerwisyCommand
        {
            get
            {
                if (_ShowSerwisyCommand == null)
                {
                    _ShowSerwisyCommand = new BaseCommand(() => Messenger.Default.Send("ShowSerwisy"));
                }
                return _ShowSerwisyCommand;
            }
        }
        #endregion
        #region Kontruktor
        public NowaNaprawaViewModel() : base("Naprawy")
        {
            item = new Naprawy();
            Messenger.Default.Register<Produkty>(this, getWybranyProdukt);
            Messenger.Default.Register<Serwisy>(this, getWybranySerwis);
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
        public int Idnaprawy { get; }
        public DateTime? DataNaprawy
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
        public string? StatusNaprawy
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
        private string? _SerwisNazwa;
        public string? SerwisNazwa
        {
            get
            {
                return _SerwisNazwa;
            }
            set
            {
                if (_SerwisNazwa != value)
                {
                    _SerwisNazwa = value;
                    base.OnPropertyChanged(() => SerwisNazwa);
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
        private string? _ProduktNazwa;
        public string? ProduktNazwa
        {
            get
            {
                return _ProduktNazwa;
            }
            set
            {
                if (_ProduktNazwa != value)
                {
                    _ProduktNazwa = value;
                    base.OnPropertyChanged(() => ProduktNazwa);
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
                        Value = Serwisy.NazwaSerwisu + " " + Serwisy.Ulica + " " + Serwisy.NrDomu + "/" + Serwisy.NrLokalu + " " + Serwisy.KodPocztowy + " " + Serwisy.Miejscowosc,
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
        public List<string> StatusNaprawyComboBox
        {
            get
            {
                return new List<string>()
                {
                    "Nowa",
                    "W toku",
                    "Zrealizowana",
                    "Anulowana"
                };
            }
        }
        #endregion
        #region ForeignKey
        private void getWybranyProdukt(Produkty produkt)
        {
            Idproduktu = produkt.Idproduktu;
            ProduktNazwa = produkt.Producent + " " + produkt.Nazwa + " " + produkt.Cena + "zł";
        }
        private void getWybranySerwis(Serwisy serwis)
        {
            Idserwisu = serwis.Idserwisu;
            SerwisNazwa = serwis.NazwaSerwisu + " " + serwis.Ulica + " " + serwis.NrDomu + "/" + serwis.NrLokalu + " " + serwis.KodPocztowy + " " + serwis.Miejscowosc;
        }
        #endregion
    }
}
