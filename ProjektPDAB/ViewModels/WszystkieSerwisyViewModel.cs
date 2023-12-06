using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class WszystkieSerwisyViewModel : WszystkieViewModel<Serwisy>
    {
        #region Konstruktor
        public WszystkieSerwisyViewModel() : base("Serwisy") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Serwisy>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.Serwisies
                );
        }
        #endregion
    }
}
