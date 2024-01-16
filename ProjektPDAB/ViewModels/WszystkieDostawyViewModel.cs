using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class WszystkieDostawyViewModel : WszystkieViewModel<DostawyForView>
    {
        #region Kontruktor
        public WszystkieDostawyViewModel() : base("Dostawy") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<DostawyForView>
                (
                    from Dostawy in projektEntities.Dostawies
                    select new DostawyForView
                    {
                        IdDostawy = Dostawy.Iddostawy,
                        NazwaDostawcy = Dostawy.IddostawcyNavigation.NazwaDostawcy,
                        DataDostawy = Dostawy.DataDostawy,
                        StatusDostawy = Dostawy.StatusDostawy
                    }
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
