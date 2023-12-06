using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class WszystkieAdresyViewModel : WszystkieViewModel<Adre>
    {
        #region Kontruktor
        public WszystkieAdresyViewModel() : base("Adresy") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Adre>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.Adres
                );
        }
        #endregion
    }
}
