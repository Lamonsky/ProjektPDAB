using GalaSoft.MvvmLight.Messaging;
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
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
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
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        private BaseCommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if(_RefreshCommand == null)
                {
                    _RefreshCommand = new BaseCommand(() => load());
                }
                return _RefreshCommand;
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
            DisplayName = displayName;//to jest ustawienie nazwy zkładki
            //tworze obiekt dostepowy do BD
            projektEntities = new ProjektEntities();
        }
        #endregion
        #region Pomocniczy
        //
        public abstract void load();
        private void add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion

        #region Sortowanie
        public abstract void Sort();
        public abstract List<string> GetComboBoxSortList();

        public abstract void Filter();
        public abstract List<string> GetComboBoxFilterList();
        public List<string> SortComboBoxListItems;
        public List<string> FilterComboBoxListItems;
        public string FindTextBox;
        public string SortField;
        #endregion
    }
}
