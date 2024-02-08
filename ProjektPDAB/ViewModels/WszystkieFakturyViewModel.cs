using GalaSoft.MvvmLight.Messaging;
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
    internal class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForView>
    {
        
        #region Konstruktor
        public WszystkieFakturyViewModel() : base("Faktury") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    } 
                );
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Numer",
                "Data Wystawienia",
                "Termin Platnosci",
                "Imie",
                "Nazwisko",
                "Adres",
                "Email",
                "Telefon",
                "Nazwa Sposobu Platnosci",
                "Typ Faktury"
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Numer",
                "Imie",
                "Nazwisko",
                "Adres",
                "Email",
                "Telefon",
                "Nazwa Sposobu Platnosci",
                "Typ Faktury"
            };
        }
        public override void Filter()
        {
            if (FilterField == "Imie")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Imie != null && item.Imie.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwisko")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Telefon")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Telefon != null && item.Telefon.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Email")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Email != null && item.Email.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Adres")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.Adres != null && item.Adres.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwa Sposobu Platnosci")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.NazwaSposobuPlatnosci != null && item.NazwaSposobuPlatnosci.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Typ Faktury")
                List = new ObservableCollection<FakturaForView>(List.Where(item => item.TypFaktury != null && item.TypFaktury.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
        }
        public override void Sort()
        {
            if (SortField == "Imie")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Imie));
            }
            else if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Nazwisko));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Email));
            }
            else if (SortField == "Adres")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.Adres));
            }
            else if (SortField == "Nazwa Sposobu Platnosci")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.NazwaSposobuPlatnosci));
            }
            else if (SortField == "Data Wystawienia")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.DataWystawienia));
            }
            else if (SortField == "Termin Platnosci")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.TerminPlatnosci));
            }
            else if (SortField == "Typ Faktury")
            {
                List = new ObservableCollection<FakturaForView>(List.OrderBy(item => item.TypFaktury));
            }
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
