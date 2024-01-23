using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class NowyDostawcaViewModel : JedenViewModel<Dostawcy>
    {
        #region Konstruktor
        public NowyDostawcaViewModel() : base("Dostawca")
        {
            item = new Dostawcy();
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
        public int Iddostawcy
        {
            get
            {
                return item.Iddostawcy;
            }
        }
        public string NazwaDostawcy
        {
            get
            {
                return item.NazwaDostawcy;
            }
            set
            {
                if (item.NazwaDostawcy != value)
                {
                    item.NazwaDostawcy = value;
                    OnPropertyChanged(() => NazwaDostawcy);
                }
            }
        }
        public string NumerTelefonu
        {
            get
            {
                return item.NumerTelefonu;
            }
            set
            {
                if (item.NumerTelefonu != value)
                {
                    item.NumerTelefonu = value;
                    OnPropertyChanged(() => NumerTelefonu);
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
        
        #endregion
    }
}
