using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class WszystkieProduktyViewModel : WszystkieViewModel<Produkty>
    {
        #region Commands
        private Produkty _WybranyProdukt;
        public Produkty WybranyProdukt
        {
            set
            {
                if(_WybranyProdukt != value)
                {
                    _WybranyProdukt = value;
                    Messenger.Default.Send(_WybranyProdukt);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranyProdukt;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieProduktyViewModel() : base("Produkty")
        {
        }

        public override void Filter()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetComboBoxFilterList()
        {
            return new List<string> { };
        }

        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Produkty>
                (
                projektEntities.Produkties
                );
        }

        public override void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
