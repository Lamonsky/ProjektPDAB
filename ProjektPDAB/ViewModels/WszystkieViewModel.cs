using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Context;
using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        private BaseCommand _ModifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (_ModifyCommand == null)
                {
                    _ModifyCommand = new BaseCommand(() => modify());
                }
                return _ModifyCommand;
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
        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        private BaseCommand _FilterCommand;
        public ICommand FilterCommand
        {
            get
            {
                if (_FilterCommand == null)
                {
                    _FilterCommand = new BaseCommand(() => Filter());
                }
                return _FilterCommand;
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
        public abstract void modify();
        #endregion

        #region Sortowanie
        public abstract void Sort();
        public abstract List<string> GetComboBoxSortList();

        public abstract void Filter();
        public abstract List<string> GetComboBoxFilterList();
        public List<string> SortComboBoxListItems
        {
            get
            {
                return GetComboBoxSortList();
            }
        }
        public List<string> FilterComboBoxListItems
        {
            get
            {
                return GetComboBoxFilterList();
            }
        }
        public string FindTextBox { get; set; }
        public string SortField { get; set; }
        public string FilterField { get; set; }
        public int ItemID { get; set; }
        #endregion
    }
}
