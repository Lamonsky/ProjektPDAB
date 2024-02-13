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
    internal class WszystkieNaprawyViewModel : WszystkieViewModel<NaprawyForView>
    {
        #region Konstruktor
        public WszystkieNaprawyViewModel() : base("Naprawy")
        {

        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<NaprawyForView>
                (
                    from Naprawy in projektEntities.Naprawies
                    select new NaprawyForView
                    {
                        Idnaprawy=Naprawy.Idnaprawy,
                        DataNaprawy=Naprawy.DataNaprawy,
                        StatusNaprawy=Naprawy.StatusNaprawy,
                        NazwaSerwisu=Naprawy.IdserwisuNavigation.NazwaSerwisu,
                        Kontakt=Naprawy.IdserwisuNavigation.Telefon + "/" + Naprawy.IdserwisuNavigation.Email,
                        Adres=Naprawy.IdserwisuNavigation.Ulica + " " + Naprawy.IdserwisuNavigation.NrDomu + "/" + Naprawy.IdserwisuNavigation.NrLokalu + " " + Naprawy.IdserwisuNavigation.KodPocztowy + " " + Naprawy.IdserwisuNavigation.Miejscowosc,
                        Nazwa=Naprawy.IdproduktuNavigation.Nazwa,
                        NazwaKategorii=Naprawy.IdproduktuNavigation.IdkategoriiNavigation.NazwaKategorii
                    }
                );
        }

        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "DataNaprawy",
                "StatusNaprawy",
                "NazwaSerwisu",
                "Kontakt",
                "NazwaProduktu",
                "NazwaKategorii",
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "StatusNaprawy",
                "NazwaSerwisu",
                "Kontakt",
                "NazwaProduktu",
                "NazwaKategorii",
            };
        }
        public override void Filter()
        {
            if (FilterField == "Status Naprawy")
                List = new ObservableCollection<NaprawyForView>(List.Where(item => item.StatusNaprawy != null && item.StatusNaprawy.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwa Serwisu")
                List = new ObservableCollection<NaprawyForView>(List.Where(item => item.NazwaSerwisu != null && item.NazwaSerwisu.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Kontakt")
                List = new ObservableCollection<NaprawyForView>(List.Where(item => item.Kontakt != null && item.Kontakt.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwa Produktu")
                List = new ObservableCollection<NaprawyForView>(List.Where(item => item.Nazwa != null && item.Nazwa.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwa Kategorii")
                List = new ObservableCollection<NaprawyForView>(List.Where(item => item.NazwaKategorii != null && item.NazwaKategorii.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
        }
        public override void Sort()
        {
            if (SortField == "Data Naprawy")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.DataNaprawy));
            }
            else if (SortField == "Status Naprawy")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.StatusNaprawy));
            }
            else if (SortField == "Nazwa Serwisu")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.NazwaSerwisu));
            }
            else if (SortField == "Kontakt")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.Kontakt));
            }
            else if (SortField == "Nazwa Produktu")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.Nazwa));
            }
            else if (SortField == "Nazwa Kategorii")
            {
                List = new ObservableCollection<NaprawyForView>(List.OrderBy(item => item.NazwaKategorii));
            }
        }
        #endregion
    }
}
