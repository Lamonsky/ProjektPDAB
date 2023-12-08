using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektPDAB.ViewModels
{
    //
    public class JedenViewModel<T> : WorkspaceViewModel
    {
        #region DB
        //cała BD
        protected ProjektEntities projektEntities;
        //dodawany obiekt
        protected T item;
        #endregion

        #region Command
        private BaseCommand _SaveAndCloseCommand;
        private BaseCommand _SaveCommand;
        //ta komenda bedzie podpieta pod przycisk Zapisz i Zamknik
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                    //kom....
                    _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                _SaveCommand = new BaseCommand(Save);
                return _SaveCommand;
            }
        }
        #endregion

        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            DisplayName = displayName;
            projektEntities = new ProjektEntities();
        }
        #endregion

        #region Pomocniczy
        public void Save()
        {
            projektEntities.Add(item);
            projektEntities.SaveChanges();

        }
        private void SaveAndClose()
        {
            //zaisujemy nowy obiekt
            Save();
            //zamykamy zakładke
            OnRequestClose();
        }
        #endregion
    }
}
