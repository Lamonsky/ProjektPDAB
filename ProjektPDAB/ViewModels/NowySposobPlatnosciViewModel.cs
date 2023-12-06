using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class NowySposobPlatnosciViewModel:JedenViewModel<SposobPlatnosci>
    {
        #region Konstruktor
        public NowySposobPlatnosciViewModel() : base("Sposób Płatności") {
            item = new SposobPlatnosci();
        }
        #endregion
        #region dane
        public int ID
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
