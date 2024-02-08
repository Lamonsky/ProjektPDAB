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
    internal class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        private BaseCommand _ShowKlienciCommand;
        public ICommand ShowKlienciCommand
        {
            get
            {
                if (_ShowKlienciCommand == null)
                {
                    _ShowKlienciCommand = new BaseCommand(() => Messenger.Default.Send("ShowKlienci"));
                }
                return _ShowKlienciCommand;
            }
        }
        #region Kontruktor
        public NowaFakturaViewModel():base("Faktura"){
            item = new Faktura();
            Messenger.Default.Register<Klienci>(this, getWybranyKlient);
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
        public int Idfaktury { get; }
        public string? Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? Idklienta
        {
            get
            {
                return item.Idklienta;
            }
            set
            {
                if (item.Idklienta != value)
                {
                    item.Idklienta = value;
                    OnPropertyChanged(() => Idklienta);
                }
            }
        }
        private string? _KlientImie;
        public string? KlientImie
        {
            get
            {
                return _KlientImie;
            }
            set
            {
                if (_KlientImie != value)
                {
                    _KlientImie = value;
                    base.OnPropertyChanged(() => KlientImie);
                }
            }
        }
        private string? _KlientNazwisko;
        public string? KlientNazwisko
        {
            get
            {
                return _KlientNazwisko;
            }
            set
            {
                if (_KlientNazwisko != value)
                {
                    _KlientNazwisko = value;
                    base.OnPropertyChanged(() => KlientNazwisko);
                }
            }
        }
        private string? _KlientAdres;
        public string? KlientAdres
        {
            get
            {
                return _KlientAdres;
            }
            set
            {
                if (_KlientAdres != value)
                {
                    _KlientAdres = value;
                    base.OnPropertyChanged(() => KlientAdres);
                }
            }
        }
        public int? IdsposobuPlatnosci
        {
            get
            {
                return item.IdsposobuPlatnosci;
            }
            set
            {
                if (item.IdsposobuPlatnosci != value)
                {
                    item.IdsposobuPlatnosci = value;
                    OnPropertyChanged(() => IdsposobuPlatnosci);
                }
            }
        }
        public int? IdtypuFaktury
        {
            get
            {
                return item.IdtypuFaktury;
            }
            set
            {
                if (item.IdtypuFaktury != value)
                {
                    item.IdtypuFaktury = value;
                    OnPropertyChanged(() => IdtypuFaktury);
                }
            }
        }
        public IQueryable<SposobPlatnosci> SposobPlatnosciComboBoxItems
        {
            get
            {
                return (
                    from IdsposobuPlatnosci in projektEntities.SposobPlatnoscis
                    select IdsposobuPlatnosci
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<TypFaktury> TypFakturyComboBoxItems
        {
            get
            {
                return (
                    from IdtypuFaktury in projektEntities.TypFakturies
                    select IdtypuFaktury
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> KlientComboBoxItems
        {
            get
            {
                return (
                    from Klienci in projektEntities.Kliencis
                    select new KeyAndValue
                    {
                        Key = Klienci.Idklienta,
                        Value = Klienci.Imie + " " + Klienci.Nazwisko
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region ForeignKey
        private void getWybranyKlient(Klienci klient)
        {
            Idklienta = klient.Idklienta;
            KlientImie = klient.Imie;
            KlientNazwisko = klient.Nazwisko;
            KlientAdres = klient.Ulica + " " + klient.NrDomu + "/" + klient.NrLokalu + " " + klient.KodPocztowy + " " + klient.Miejscowosc;
        }
        #endregion
    }
}
