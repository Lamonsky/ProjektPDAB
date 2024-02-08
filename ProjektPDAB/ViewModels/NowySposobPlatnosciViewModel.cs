using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class NowySposobPlatnosciViewModel : JedenViewModel<SposobPlatnosci>
    {
        #region Konstruktor
        public NowySposobPlatnosciViewModel() : base("SposobPlatnosci")
        {
            item = new SposobPlatnosci();
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
        public int IdsposobuPlatnosci
        {
            get
            {
                return item.IdsposobuPlatnosci;
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
        #endregion
    }
}
