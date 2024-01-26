using ProjektPDAB.Models.Entities;
using ProjektPDAB.Validators;
using ProjektPDAB.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class ModyfikujKlientViewModel : JedenViewModel<Klienci>, IDataErrorInfo
    {
        #region Konstruktor
        public ModyfikujKlientViewModel(Klienci item) : base("Klienci")
        {
            item = item;
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
        public int Idklienta
        {
            get
            {
                return item.Idklienta;
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
        public string NipPesel
        {
            get
            {
                return item.NipPesel;
            }
            set
            {
                if (item.NipPesel != value)
                {
                    item.NipPesel = value;
                    OnPropertyChanged(() => NipPesel);
                }
            }
        }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Imie):
                        {
                            return Imie.ValidateFirstLetterUp();
                        }
                    case nameof(Nazwisko):
                        {
                            return Nazwisko.ValidateFirstLetterUp();
                        }
                    case nameof(Miejscowosc):
                        {
                            return Miejscowosc.ValidateFirstLetterUp();
                        }
                    case nameof(Ulica):
                        {
                            return Ulica.ValidateFirstLetterUp();
                        }
                    case nameof(NipPesel):
                        {
                            return NipPesel.NIPPeselValidator();
                        }
                    default: return string.Empty;
                }
            }
        }

        public string Error { get; }
        public bool HasErrors => string.IsNullOrEmpty(Error);
        public override bool IsValid()
        {
            return HasErrors;
        }
        #endregion

    }
}
