using ProjektPDAB.Models.Context;
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
    public class WszyscyDostawcyViewModel : WszystkieViewModel<Dostawcy>
    {
        #region Konstruktor
        public WszyscyDostawcyViewModel() : base("Dostawcy") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Dostawcy>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.Dostawcies
                );
        }
        #endregion
    }
}
