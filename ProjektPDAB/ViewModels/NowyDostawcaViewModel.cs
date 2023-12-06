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
        public string Kontakt
        {
            get
            {
                return item.Kontakt;
            }
            set
            {
                if (item.Kontakt != value)
                {
                    item.Kontakt = value;
                    OnPropertyChanged(() => Kontakt);
                }
            }
        }
        #endregion
    }
}
