using ProjektPDAB.Models.Context;
using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.Entities;
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
        public override List<string> GetComboBoxSortList()
        {
            throw new NotImplementedException();
        }
        public override List<string> GetComboBoxFilterList()
        {
            throw new NotImplementedException();
        }
        public override void Filter()
        {
            throw new NotImplementedException();
        }
        public override void Sort()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
