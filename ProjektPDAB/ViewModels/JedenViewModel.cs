using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (IsValid())
            {
                //zaisujemy nowy obiekt
                Save();
                //zamykamy zakładke
                OnRequestClose();
            }
            else
            {
                MessageBox.Show(Application.Current.MainWindow, "Popraw błędy w formularzu");
            }
        }
        public List<string> KrajComboBox
        {
            get
            {
                return new List<string>()
                {
                    "Austria",
                    "Belgia",
                    "Bułgaria",
                    "Chorwacja",
                    "Cypr",
                    "Czechy",
                    "Dania",
                    "Estonia",
                    "Finlandia",
                    "Francja",
                    "Niemcy",
                    "Grecja",
                    "Węgry",
                    "Irlandia",
                    "Włochy",
                    "Łotwa",
                    "Litwa",
                    "Luksemburg",
                    "Malta",
                    "Holandia",
                    "Polska",
                    "Portugalia",
                    "Rumunia",
                    "Słowacja",
                    "Słowenia",
                    "Hiszpania",
                    "Szwecja",
                    "Wielka Brytania",
                    "Stany Zjednoczone",
                    "Brazylia",
                    "Rosja",
                    "Ukraina",
                    "Białoruś",
                    "Kanada",
                    "Meksyk",
                    "Argentyna"
                };
            }
        }
        public List<string> WojewodztwaComboBox
        {
            get
            {
                return new List<string>()
                {
                    "Zachodniopomorskie",
                    "Pomorskie",
                    "Warmińsko-Mazurskie",
                    "Lubuskie",
                    "Wielkopolskie",
                    "Kujawsko-Pomorskie",
                    "Mazowieckie",
                    "Podlaskie",
                    "Dolnośląskie",
                    "Łódzkie",
                    "Lubelskie",
                    "Opolskie",
                    "Śląskie",
                    "Świętokrzyskie",
                    "Małopolskie",
                    "Podkarpackie"
                };
            }
        }
        #endregion

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
