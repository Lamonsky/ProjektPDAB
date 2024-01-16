using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class WszystkieKategorieViewModel : WszystkieViewModel<Kategorie>
    {
        #region Konstruktor
        public WszystkieKategorieViewModel() : base("Kategorie") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Kategorie>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.Kategories
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
