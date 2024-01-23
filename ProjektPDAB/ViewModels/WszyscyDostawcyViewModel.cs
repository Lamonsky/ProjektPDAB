using ProjektPDAB.Models.Context;
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
                    from Dostawcy in projektEntities.Dostawcies
                    select new Dostawcy
                    {
                        Iddostawcy = Dostawcy.Iddostawcy,
                        NazwaDostawcy = Dostawcy.NazwaDostawcy,
                        NumerTelefonu = Dostawcy.NumerTelefonu,
                        Email = Dostawcy.Email,
                        Ulica = Dostawcy.Ulica + " " + 
                        Dostawcy.NrDomu + "/" + Dostawcy.NrLokalu + " " +
                        Dostawcy.KodPocztowy + " " + Dostawcy.Miejscowosc,
                        Wojewodztwo = Dostawcy.Wojewodztwo,
                        Kraj = Dostawcy.Kraj
                    }
                );
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Nazwa dostawcy",
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
                "Nazwa dostawcy",
                "Telefon",
                "Email",
                "Ulica",
                "Wojewodztwo",
                "Kraj"
            };
        }
        public override void Filter()
        {
            if (FilterField == "Nazwa dostawcy")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.NazwaDostawcy != null && item.NazwaDostawcy.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Telefon")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.NumerTelefonu != null && item.NumerTelefonu.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Email")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.Email != null && item.Email.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Ulica")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.Ulica != null && item.Ulica.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Wojewodztwo")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Kraj")
                List = new ObservableCollection<Dostawcy>(List.Where(item => item.Kraj != null && item.Kraj.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
        }
        public override void Sort()
        {
            if (SortField == "Nazwa serwisu")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.NazwaDostawcy));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.NumerTelefonu));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.Email));
            }
            else if (SortField == "Ulica")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.Ulica));
            }
            else if (SortField == "Wojewodztwo")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.Wojewodztwo));
            }
            else if (SortField == "Kraj")
            {
                List = new ObservableCollection<Dostawcy>(List.OrderBy(item => item.Kraj));
            }
        }
        #endregion
    }
}
