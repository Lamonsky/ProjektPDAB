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
                    from Serwisy in projektEntities.Serwisies
                    select new Serwisy
                    {
                        Idserwisu = Serwisy.Idserwisu,
                        NazwaSerwisu = Serwisy.NazwaSerwisu,
                        Telefon = Serwisy.Telefon,
                        Email = Serwisy.Email,
                        Ulica = Serwisy.Ulica + " " +
                        Serwisy.NrDomu + "/" + Serwisy.NrLokalu + " " +
                        Serwisy.KodPocztowy + " " + Serwisy.Miejscowosc,
                        Wojewodztwo = Serwisy.Wojewodztwo,
                        Kraj = Serwisy.Kraj,
                    }
                );
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Nazwa serwisu",
                "Telefon",
                "Email",
                "Ulica",
                "Wojewodztwo",
                "Kraj"
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Nazwa serwisu",
                "Telefon",
                "Email",
                "Ulica",
                "Wojewodztwo",
                "Kraj"
            };
        }
        public override void Filter()
        {
            if (FilterField == "Nazwa serwisu")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.NazwaSerwisu != null && item.NazwaSerwisu.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Telefon")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.Telefon != null && item.Telefon.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Email")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.Email != null && item.Email.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Ulica")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.Ulica != null && item.Ulica.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Wojewodztwo")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Kraj")
                List = new ObservableCollection<Serwisy>(List.Where(item => item.Kraj != null && item.Kraj.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
        }
        public override void Sort()
        {
            if(SortField == "Nazwa serwisu")
            {
                List = new ObservableCollection<Serwisy> (List.OrderBy(item => item.NazwaSerwisu));
            }
            else if(SortField == "Telefon")
            {
                List = new ObservableCollection<Serwisy>(List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<Serwisy>(List.OrderBy(item => item.Email));
            }
            else if (SortField == "Ulica")
            {
                List = new ObservableCollection<Serwisy>(List.OrderBy(item => item.Ulica));
            }
            else if (SortField == "Wojewodztwo")
            {
                List = new ObservableCollection<Serwisy>(List.OrderBy(item => item.Wojewodztwo));
            }
            else if (SortField == "Kraj")
            {
                List = new ObservableCollection<Serwisy>(List.OrderBy(item => item.Kraj));
            }
        }
        #endregion
    }
}
