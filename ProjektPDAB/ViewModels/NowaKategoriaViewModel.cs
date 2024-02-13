using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class NowaKategoriaViewModel : JedenViewModel<Kategorie>
    {
        #region Konstruktor
        public NowaKategoriaViewModel() : base("Kategorie")
        {
            item = new Kategorie();
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
        public int Idkategorii
        {
            get
            {
                return item.Idkategorii;
            }
        }
        public string NazwaKategorii
        {
            get
            {
                return item.NazwaKategorii;
            }
            set
            {
                if (item.NazwaKategorii != value)
                {
                    item.NazwaKategorii = value;
                    OnPropertyChanged(() => NazwaKategorii);
                }
            }
        }
        #endregion
    }
}
