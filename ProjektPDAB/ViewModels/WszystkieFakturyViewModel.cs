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
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        Adres = Faktura.IdklientaNavigation.IdadresuNavigation.Ulica,
                        Nazwa = Faktura.IdsposobuPlatnosciNavigation.Nazwa
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
