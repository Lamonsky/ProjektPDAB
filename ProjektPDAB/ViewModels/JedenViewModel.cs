using ProjektPDAB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektPDAB.ViewModels
{
    //
    public class JedenViewModel<T>:WorkspaceViewModel
    {
        #region DB
        //cała BD
        //protected FakturyEntities fakturyEntities;
        //dodawany obiekt
        protected T item;
        #endregion

        #region Command
        private BaseCommand _SaveAndCloseCommand;
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
        #endregion

        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            //fakturyEntities = new FakturyEntities();
        }
        #endregion

        #region Pomocniczy
        public void Save()
        {
            //fakturyEntities.Add(item);
            //fakturyEntities.SaveChanges();

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
