using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektPDAB.Models.Context;
using ProjektPDAB.Helpers;
using System.Windows.Input;

namespace ProjektPDAB.ViewModels
{
    class GeneratorFakturViewModel : JedenViewModel<Faktura>
    {
        private BaseCommand _ShowFakturyForGeneratorCommand;
        public ICommand ShowFakturyForGeneratorCommand
        {
            get
            {
                if (_ShowFakturyForGeneratorCommand == null)
                {
                    _ShowFakturyForGeneratorCommand = new BaseCommand(() => Messenger.Default.Send("ShowFakturyForGenerator"));
                }
                return _ShowFakturyForGeneratorCommand;
            }
        }
        #region Konstruktor
        public GeneratorFakturViewModel() : base("GeneratorFaktur") {
            Messenger.Default.Register<Faktura>(this, getWybranaFaktura);
        }
        #endregion

        private void getWybranaFaktura(Faktura faktura)
        {
            Klienci klient = projektEntities.Kliencis.FirstOrDefault(e => e.Idklienta == faktura.Idklienta);
            SposobPlatnosci sposobplatnosci = projektEntities.SposobPlatnoscis.FirstOrDefault(e => e.IdsposobuPlatnosci == faktura.IdsposobuPlatnosci);
            TypFaktury typfaktury = projektEntities.TypFakturies.FirstOrDefault(e => e.IdtypuFaktury == faktura.IdtypuFaktury);
            Numer = faktura.Numer;
            DataWystawienia = faktura.DataWystawienia;
            TerminPlatnosci = faktura.TerminPlatnosci;
            KlientNazwa = klient.Imie + " " + klient.Nazwisko;
            KlientAdres = klient.Ulica + " " + klient.NrDomu + "/" + klient.NrLokalu;
            KlientMiejscowosc = klient.Miejscowosc;
            KlientKodPocztowy = klient.KodPocztowy;
            SposobPlatnosciNazwa = sposobplatnosci.Nazwa;
            TypFakturyNazwa = typfaktury.Nazwa;
        }

        #region Dane
        private string? _Numer;
        public string? Numer
        {
            get
            {
                return _Numer;
            }
            set
            {
                if (_Numer != value)
                {
                    _Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        private DateTime? _DataWystawienia;
        public DateTime? DataWystawienia
        {
            get
            {
                return _DataWystawienia;
            }
            set
            {
                if(_DataWystawienia != value)
                {
                    _DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        private DateTime? _TerminPlatnosci;
        public DateTime? TerminPlatnosci
        {
            get
            {
                return _TerminPlatnosci;
            }
            set
            {
                if (_TerminPlatnosci != value)
                {
                    _TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        private string? _KlientNazwa;
        public string? KlientNazwa
        {
            get
            {
                return _KlientNazwa;
            }
            set
            {
                if (_KlientNazwa != value)
                {
                    _KlientNazwa = value;
                    base.OnPropertyChanged(() => KlientNazwa);
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
        private string _KlientMiejscowosc;
        public string KlientMiejscowosc
        {
            get
            {
                return _KlientMiejscowosc;
            }
            set
            {
                if (_KlientMiejscowosc != value)
                {
                    _KlientMiejscowosc = value;
                    base.OnPropertyChanged(() => KlientMiejscowosc);
                }
            }
        }
        private string? _KlientKodPocztowy;
        public string KlientKodPocztowy
        {
            get
            {
                return _KlientKodPocztowy;
            }
            set
            {
                if (_KlientKodPocztowy != value)
                {
                    _KlientKodPocztowy = value;
                    base.OnPropertyChanged(() => KlientKodPocztowy);
                }
            }
        }
        private string _SposobPlatnosciNazwa;
        public string SposobPlatnosciNazwa
        {
            get
            {
                return _SposobPlatnosciNazwa;
            }
            set
            {
                if (_SposobPlatnosciNazwa != value)
                {
                    _SposobPlatnosciNazwa = value;
                    base.OnPropertyChanged(() => SposobPlatnosciNazwa);
                }
            }
        }
        private string _TypFakturyNazwa;
        public string TypFakturyNazwa
        {
            get
            {
                return _TypFakturyNazwa;
            }
            set
            {
                if (_TypFakturyNazwa != value)
                {
                    _TypFakturyNazwa = value;
                    base.OnPropertyChanged(() => TypFakturyNazwa);
                }
            }
        }
        #endregion


        

    }
}
