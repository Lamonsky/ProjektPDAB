using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class WszyscyPracownicyViewModel : WszystkieViewModel<Pracownicy>
    {
        #region Konstruktor
        public WszyscyPracownicyViewModel() : base("Pracownicy") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Pracownicy>
                (
                    from Pracownicy in projektEntities.Pracownicies
                    select new Pracownicy
                    {
                        Idpracownika = Pracownicy.Idpracownika,
                        Imie = Pracownicy.Imie,
                        Nazwisko = Pracownicy.Nazwisko,
                        Telefon = Pracownicy.Telefon,
                        Email = Pracownicy.Email,
                        Stanowisko = Pracownicy.Stanowisko,
                        DataZatrudnienia = Pracownicy.DataZatrudnienia,
                        Pensja = Pracownicy.Pensja,
                        Ulica = Pracownicy.Ulica + " " +
                        Pracownicy.NrDomu + "/" + Pracownicy.NrLokalu + " " +
                        Pracownicy.KodPocztowy + " " + Pracownicy.Miejscowosc,
                        Wojewodztwo = Pracownicy.Wojewodztwo,
                        Kraj = Pracownicy.Kraj,
                    }
                );
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Imie",
                "Nazwisko",
                "Telefon",
                "Email",
                "Stanowisko",
                "Data Zatrudnienia",
                "Pensja",
                "Ulica",
                "Wojewodztwo",
                "Kraj"
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Imie",
                "Nazwisko",
                "Telefon",
                "Email",
                "Stanowisko",
                "Pensja",
                "Ulica",
                "Wojewodztwo",
                "Kraj"
            };
        }
        public override void Filter()
        {
            if (FilterField == "Imie")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Imie != null && item.Imie.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwisko")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Nazwisko != null && item.Nazwisko.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Telefon")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Telefon != null && item.Telefon.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Email")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Email != null && item.Email.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Ulica")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Ulica != null && item.Ulica.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Wojewodztwo")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Kraj")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Kraj != null && item.Kraj.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Stanowisko")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Stanowisko != null && item.Stanowisko.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Pensja")
                List = new ObservableCollection<Pracownicy>(List.Where(item => item.Pensja != null && item.Pensja.Equals(decimal.Parse(FindTextBox))));
        }
        public override void Sort()
        {
            if (SortField == "Imie")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Imie));
            }
            else if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Nazwisko));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Email));
            }
            else if (SortField == "Ulica")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Ulica));
            }
            else if (SortField == "Wojewodztwo")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Wojewodztwo));
            }
            else if (SortField == "Kraj")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Kraj));
            }
            else if (SortField == "Stanowisko")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Stanowisko));
            }
            else if (SortField == "Data Zatrudnienia")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.DataZatrudnienia));
            }
            else if (SortField == "Pensja")
            {
                List = new ObservableCollection<Pracownicy>(List.OrderBy(item => item.Pensja));
            }
        }
        #endregion
    }
}
