using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektPDAB.ViewModels
{
    //
    //
    public abstract class WszystkieViewModel<T>:WorkspaceViewModel
    {
        #region DB
        protected readonly ProjektEntities projektEntities;
        #endregion
        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        #endregion
        #region Kolekcja
        //tu ....
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                //jak lista....
                if (_List == null)
                {
                    load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;//to jest ustawienie nazwy zkładki
            //tworze obiekt dostepowy do BD
            //fakturyEntities = new FakturyEntities();
        }
        #endregion
        #region Pomocniczy
        //
        public abstract void load();
        #endregion
    }
}
