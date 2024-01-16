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
        public WszystkieSerwisyViewModel() : base("Serwisy") {
        }
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
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Serwis",
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Serwis",
            };
        }
        public override void Filter()
        {
            throw new NotImplementedException();
        }
        public override void Sort()
        {
            if(SortField == "Data")
            {
                List = new ObservableCollection<Serwisy> (List.OrderBy(item => item.NazwaSerwisu));
            }
        }
        #endregion
    }
}
