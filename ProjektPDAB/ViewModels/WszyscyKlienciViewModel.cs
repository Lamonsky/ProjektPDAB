<<<<<<< HEAD
﻿using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Models.Entities;
=======
﻿using ProjektPDAB.Models.Entities;
using ProjektPDAB.Views;
>>>>>>> 230d8b7aa4a3bc21626d30bfd4f5ef60fc46a281
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektPDAB.ViewModels
{
    class WszyscyKlienciViewModel : WszystkieViewModel<Klienci>
    {
        #region Commands
        private Klienci _WybranyKlient;
        public Klienci WybranyKlient
        {
            get
            {
                return _WybranyKlient;
            }
            set
            {
                if(_WybranyKlient != value)
                {
                    _WybranyKlient = value;
                    Messenger.Default.Send(_WybranyKlient);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszyscyKlienciViewModel() : base("Klienci") { }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<Klienci>
                (
                    from Klienci in projektEntities.Kliencis
                    select new Klienci
                    {
                        Idklienta = Klienci.Idklienta,
                        Imie = Klienci.Imie,
                        Nazwisko = Klienci.Nazwisko,
                        Telefon = Klienci.Telefon,
                        Email = Klienci.Email,
                        Ulica = Klienci.Ulica + " " +
                        Klienci.NrDomu + "/" + Klienci.NrLokalu + " " +
                        Klienci.KodPocztowy + " " + Klienci.Miejscowosc,
                        Wojewodztwo = Klienci.Wojewodztwo,
                        Kraj = Klienci.Kraj,
                        NipPesel = Klienci.NipPesel
                    }
                );
        }
        public override void modify()
        {
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<String>() {
                "Imie",
                "Nazwisko",
                "Telefon",
                "Email",
                "Ulica",
                "Wojewodztwo",
                "Kraj",
                "NIP/PESEL"
            };
        }
        public override List<string> GetComboBoxFilterList()
        {
            return new List<String>() {
                "Imie",
                "Nazwisko",
                "Telefon",
                "Email",
                "Ulica",
                "Wojewodztwo",
                "Kraj",
                "NIP/PESEL"
            };
        }
        public override void Filter()
        {
            if (FilterField == "Imie")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Imie != null && item.Imie.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Nazwisko")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Nazwisko != null && item.Nazwisko.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Telefon")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Telefon != null && item.Telefon.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Email")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Email != null && item.Email.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Ulica")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Ulica != null && item.Ulica.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Wojewodztwo")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "Kraj")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Kraj != null && item.Kraj.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
            else if (FilterField == "NIP/PESEL")
                List = new ObservableCollection<Klienci>(List.Where(item => item.NipPesel != null && item.NipPesel.Contains(FindTextBox, System.StringComparison.CurrentCultureIgnoreCase)));
        }
        public override void Sort()
        {
            if (SortField == "Imie")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Imie));
            }
            else if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Nazwisko));
            }
            else if (SortField == "Telefon")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Telefon));
            }
            else if (SortField == "Email")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Email));
            }
            else if (SortField == "Ulica")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Ulica));
            }
            else if (SortField == "Wojewodztwo")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Wojewodztwo));
            }
            else if (SortField == "Kraj")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Kraj));
            }
            else if (SortField == "NIP/PESEL")
            {
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.NipPesel));
            }
        }
        #endregion
    }
}
