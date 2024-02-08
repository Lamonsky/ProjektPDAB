using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
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
    class WszystkieFakturyForGeneratorViewModel : WszystkieViewModel<Faktura>
    {
        #region Commands
        private Faktura _WybranaFaktura;
        public Faktura WybranaFaktura
        {
            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    Messenger.Default.Send(_WybranaFaktura);
                    OnRequestClose();
                }
            }
            get
            {
                return _WybranaFaktura;
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieFakturyForGeneratorViewModel() : base("Faktury")
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
            List = new ObservableCollection<Faktura>
                (
                projektEntities.Fakturas
                );
        }

        public override void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
