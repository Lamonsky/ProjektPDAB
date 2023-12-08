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
    internal class WszystkieNaprawyViewModel:WszystkieViewModel<NaprawyForView>
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
                        Kontakt=Naprawy.IdserwisuNavigation.Kontakt,
                        Adres=Naprawy.IdserwisuNavigation.Adres,
                        Nazwa=Naprawy.IdnaprawyNavigation.Nazwa,
                        NazwaKategorii=Naprawy.IdnaprawyNavigation.IdkategoriiNavigation.NazwaKategorii
                    }
                );
        }
        #endregion
    }
}
