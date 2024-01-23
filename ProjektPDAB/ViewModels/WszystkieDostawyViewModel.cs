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
                        NazwaDostawcy = Dostawy.IddostawcyNavigation.NazwaDostawcy + " " + 
                        Dostawy.IddostawcyNavigation.Ulica + " " + Dostawy.IddostawcyNavigation.NrDomu + "/" + 
                        Dostawy.IddostawcyNavigation.NrLokalu + " " + Dostawy.IddostawcyNavigation.KodPocztowy + " " + 
                        Dostawy.IddostawcyNavigation.Miejscowosc,
                        DataDostawy = Dostawy.DataDostawy,
                        StatusDostawy = Dostawy.StatusDostawy,
                        NazwaProduktu = Dostawy.IdproduktuNavigation.Nazwa,
                        CenaProduktu = Dostawy.IdproduktuNavigation.Cena,
                        Ilosc = Dostawy.Ilosc
                    }
                );
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Nazwa Dostawcy",
                "Data Dostawy",
                "Status Dostawy",
                "Nazwa Produktu",
                "Cena Produktu",
                "Ilosc",
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Nazwa Dostawcy",
                "Status Dostawy",
                "Nazwa Produktu",
                "Cena Produktu",
                "Ilosc",
            };
        }
        public override void Filter()
        {
            if (FilterField == "Nazwa Dostawcy")
                List = new ObservableCollection<DostawyForView>(List.Where(item => item.NazwaDostawcy != null && item.NazwaDostawcy.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Status Dostawy")
                List = new ObservableCollection<DostawyForView>(List.Where(item => item.StatusDostawy != null && item.StatusDostawy.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwa Produktu")
                List = new ObservableCollection<DostawyForView>(List.Where(item => item.NazwaProduktu != null && item.NazwaProduktu.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Ilosc")
                List = new ObservableCollection<DostawyForView>(List.Where(item => item.Ilosc != null && item.Ilosc.Equals(int.Parse(FindTextBox))));
            else if (FilterField == "Cena Produktu")
                List = new ObservableCollection<DostawyForView>(List.Where(item => item.CenaProduktu != null && item.CenaProduktu.Equals(decimal.Parse(FindTextBox))));
        }
        public override void Sort()
        {
            if (SortField == "Nazwa Dostawcy")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.NazwaDostawcy));
            }
            else if (SortField == "Status Dostawy")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.StatusDostawy));
            }
            else if (SortField == "Data Dostawy")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.DataDostawy));
            }
            else if (SortField == "Nazwa Produktu")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.NazwaProduktu));
            }
            else if (SortField == "Ilosc")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.Ilosc));
            }
            else if (SortField == "Cena Produktu")
            {
                List = new ObservableCollection<DostawyForView>(List.OrderBy(item => item.CenaProduktu));
            }
        }
        #endregion
    }
}
