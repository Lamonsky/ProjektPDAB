using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class WszyscyKlienciViewModel : WszystkieViewModel<Klienci>
    {
        #region Konstruktor
        public WszyscyKlienciViewModel() : base("Klienci") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Klienci>
                (
                    //z bazy danych pobieram wszystkie towary
                    projektEntities.Kliencis
                );
        }
        #endregion
    }
}
