using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class NowyPracownikViewModel : JedenViewModel<Pracownicy>
    {
        #region Konstruktor
        public NowyPracownikViewModel() : base("Pracownik")
        {
            item = new Pracownicy();
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
        public int Idpracownika
        {
            get
            {
                return item.Idpracownika;
            }
        }
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                if (item.Stanowisko != value)
                {
                    item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
                }
            }
        }
        public DateTime? DataZatrudnienia
        {
            get
            {
                return item.DataZatrudnienia;
            }
            set
            {
                if (item.DataZatrudnienia != value)
                {
                    item.DataZatrudnienia = value;
                    OnPropertyChanged(() => DataZatrudnienia);
                }
            }
        }
        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                if (item.Miejscowosc != value)
                {
                    item.Miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                if (item.NrDomu != value)
                {
                    item.NrDomu = value;
                    OnPropertyChanged(() => NrDomu);
                }
            }
        }
        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                if (item.NrLokalu != value)
                {
                    item.NrLokalu = value;
                    OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Wojewodztwo
        {
            get
            {
                return item.Wojewodztwo;
            }
            set
            {
                if (item.Wojewodztwo != value)
                {
                    item.Wojewodztwo = value;
                    OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                if (item.Kraj != value)
                {
                    item.Kraj = value;
                    OnPropertyChanged(() => Kraj);
                }
            }
        }
        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }
        public decimal? Pensja
        {
            get
            {
                return item.Pensja;
            }
            set
            {
                if (item.Pensja != value)
                {
                    item.Pensja = value;
                    OnPropertyChanged(() => Pensja);
                }
            }
        }
        #endregion
    }
}
