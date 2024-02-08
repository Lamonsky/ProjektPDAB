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
    class NowaDostawaViewModel : JedenViewModel<Dostawy>
    {
        #region Commands
        private BaseCommand _ShowProduktyCommand;
        public ICommand ShowProduktyCommand
        {
            get
            {
                if(_ShowProduktyCommand == null)
                {
                    _ShowProduktyCommand = new BaseCommand(() => Messenger.Default.Send("ShowProdukty"));
                }
                return _ShowProduktyCommand;
            }
        }
        private BaseCommand _ShowDostawcyCommand;
        public ICommand ShowDostawcyCommand
        {
            get
            {
                if (_ShowDostawcyCommand == null)
                {
                    _ShowDostawcyCommand = new BaseCommand(() => Messenger.Default.Send("ShowDostawcy"));
                }
                return _ShowDostawcyCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowaDostawaViewModel() : base("Dostawy")
        {
            item = new Dostawy();
            Messenger.Default.Register<Produkty>(this, getWybranyProdukt);
            Messenger.Default.Register<Dostawcy>(this, getWybranyDostawca);
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
        public int IdDostawy { get; }
        public DateTime? DataDostawy
        {
            get
            {
                return item.DataDostawy;
            }
            set
            {
                if (item.DataDostawy != value)
                {
                    item.DataDostawy = value;
                    OnPropertyChanged(() => DataDostawy);
                }
            }
        }
        public string? StatusDostawy
        {
            get
            {
                return item.StatusDostawy;
            }
            set
            {
                if (item.StatusDostawy != value)
                {
                    item.StatusDostawy = value;
                    OnPropertyChanged(() => StatusDostawy);
                }
            }
        }
        public int? Iddostawcy
        {
            get
            {
                return item.Iddostawcy;
            }
            set
            {
                if (item.Iddostawcy != value)
                {
                    item.Iddostawcy = value;
                    OnPropertyChanged(() => Iddostawcy);
                }
            }
        }
        public IQueryable<Dostawcy> DostawcyComboBoxItemsOneArgument
        {
            get
            {
                return (
                    from NazwaDostawcy in projektEntities.Dostawcies
                    select NazwaDostawcy
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> DostawcyComboBoxItemsMultipleArguments
        {
            get
            {
                return (
                    from Dostawcy in projektEntities.Dostawcies
                    select new KeyAndValue
                    {
                        Key = Dostawcy.Iddostawcy,
                        Value = Dostawcy.NazwaDostawcy + " " + Dostawcy.NumerTelefonu + "\\" + Dostawcy.Email
                    }
                ).ToList().AsQueryable();
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
                if(_ProduktNazwa != value)
                {
                    _ProduktNazwa = value;
                    base.OnPropertyChanged(() => ProduktNazwa);
                }
            }
        }
        private string _DostawcaNazwa;
        public string DostawcaNazwa
        {
            get
            {
                return _DostawcaNazwa;
            }
            set
            {
                if(_DostawcaNazwa != value)
                {
                    _DostawcaNazwa = value;
                    base.OnPropertyChanged(() => DostawcaNazwa);
                }
            }
        }
        public IQueryable<Produkty> ProduktyComboBoxItemsOneArgument
        {
            get
            {
                return (
                    from Nazwa in projektEntities.Produkties
                    select Nazwa
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> ProduktyComboBoxItemsMultipleArguments
        {
            get
            {
                return (
                    from Produkty in projektEntities.Produkties
                    select new KeyAndValue
                    {
                        Key = Produkty.Idproduktu,
                        Value = Produkty.Nazwa + " " + Produkty.Cena
                    }
                ).ToList().AsQueryable();
            }
        }

        public List<string> StatusDostawyComboBox
        {
            get
            {
                return new List<string>()
                {
                    "Nowa",
                    "W toku",
                    "Dostarczona",
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
        private void getWybranyDostawca(Dostawcy dostawca)
        {
            Iddostawcy = dostawca.Iddostawcy;
            DostawcaNazwa = dostawca.NazwaDostawcy + " " + dostawca.NumerTelefonu + "\\" + dostawca.Email;
        }
        #endregion
    }
}
