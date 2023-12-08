using ProjektPDAB.Models.Entities;
using ProjektPDAB.Views;
using ProjektPDAB.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobPlatnosci>
    {
        #region Kontruktor
        public WszystkieSposobyPlatnosciViewModel() : base("Sposoby Płatności") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<SposobPlatnosci>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.SposobPlatnoscis
                );
        }
        #endregion
    }
}
