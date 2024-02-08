using GalaSoft.MvvmLight.Messaging;
using ProjektPDAB.Helpers;
using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using CsvHelper;
using Microsoft.VisualBasic;
using System.Globalization;
using System.IO;

namespace ProjektPDAB.ViewModels
{
    class RaportFakturViewModel : WszystkieViewModel<FakturaForView>
    {
        #region Commands
        private BaseCommand _ShowKlienciCommand;
        public ICommand ShowKlienciCommand
        {
            get
            {
                if (_ShowKlienciCommand == null)
                {
                    _ShowKlienciCommand = new BaseCommand(() => Messenger.Default.Send("ShowKlienci"));
                }
                return _ShowKlienciCommand;
            }
        }
        private BaseCommand _GenerujRaportCommand;
        public ICommand GenerujRaportCommand
        {
            get
            {
                if (_GenerujRaportCommand == null)
                {
                    _GenerujRaportCommand = new BaseCommand(() => generujraport());
                }
                return _GenerujRaportCommand;
            }
        }
        private BaseCommand _GenerateCSVCommand;
        public ICommand GenerateCSVCommand
        {
            get
            {
                if (_GenerateCSVCommand == null)
                {
                    _GenerateCSVCommand = new BaseCommand(() => generujcsv());
                }
                return _GenerateCSVCommand;
            }
        }
        #endregion
        #region Dane
        private int? _IdSposobuPlatnosci;
        public int? IdsposobuPlatnosci
        {
            get
            {
                return _IdSposobuPlatnosci;
            }
            set
            {
                if (_IdSposobuPlatnosci != value)
                {
                    _IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdsposobuPlatnosci);
                }
            }
        }
        private DateTime? _DataWystawieniaOd = minDateTime;
        public DateTime? DataWystawieniaOd
        {
            get
            {
                return _DataWystawieniaOd;
            }
            set
            {
                if (_DataWystawieniaOd != value)
                {
                    _DataWystawieniaOd = value;
                    OnPropertyChanged(() => DataWystawieniaOd);
                }
            }
        }
        private DateTime? _DataWystawieniaDo = DateTime.MaxValue;
        public DateTime? DataWystawieniaDo
        {
            get
            {
                return _DataWystawieniaDo;
            }
            set
            {
                if (_DataWystawieniaDo != value)
                {
                    _DataWystawieniaDo = value;
                    OnPropertyChanged(() => DataWystawieniaDo);
                }
            }
        }
        private DateTime? _TerminPlatnosciOd = minDateTime;
        public DateTime? TerminPlatnosciOd
        {
            get
            {
                return _TerminPlatnosciOd;
            }
            set
            {
                if (_TerminPlatnosciOd != value)
                {
                    _TerminPlatnosciOd = value;
                    OnPropertyChanged(() => TerminPlatnosciOd);
                }
            }
        }
        private DateTime? _TerminPlatnosciDo = DateTime.MaxValue;
        public DateTime? TerminPlatnosciDo
        {
            get
            {
                return _TerminPlatnosciDo;
            }
            set
            {
                if (_TerminPlatnosciDo != value)
                {
                    _TerminPlatnosciDo = value;
                    OnPropertyChanged(() => TerminPlatnosciDo);
                }
            }
        }
        private int? _Idklienta;
        public int? Idklienta
        {
            get
            {
                return _Idklienta;
            }
            set
            {
                if (_Idklienta != value)
                {
                    _Idklienta = value;
                    OnPropertyChanged(() => Idklienta);
                }
            }
        }
        private string? _KlientNazwa;
        public string? KlientNazwa
        {
            get
            {
                return _KlientNazwa;
            }
            set
            {
                if (_KlientNazwa != value)
                {
                    _KlientNazwa = value;
                    base.OnPropertyChanged(() => KlientNazwa);
                }
            }
        }
        private int? _IdtypuFaktury;
        public int? IdtypuFaktury
        {
            get
            {
                return _IdtypuFaktury;
            }
            set
            {
                if (_IdtypuFaktury != value)
                {
                    _IdtypuFaktury = value;
                    OnPropertyChanged(() => IdtypuFaktury);
                }
            }
        }
        public IQueryable<SposobPlatnosci> SposobPlatnosciComboBoxItems
        {
            get
            {
                return (
                    from IdsposobuPlatnosci in projektEntities.SposobPlatnoscis
                    select IdsposobuPlatnosci
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<TypFaktury> TypFakturyComboBoxItems
        {
            get
            {
                return (
                    from IdtypuFaktury in projektEntities.TypFakturies
                    select IdtypuFaktury
                ).ToList().AsQueryable();
            }
        }
        private static DateTime minDateTime = new DateTime(1753,1,1);
        #endregion

        #region Konstruktor
        public RaportFakturViewModel() : base("RaportFaktur") {
            Messenger.Default.Register<Klienci>(this, getWybranyKlient);
        }


        #endregion
        #region Helpers
        public override void Filter()
        {
        }

        public override List<string> GetComboBoxFilterList()
        {
            return new List<string> { };
        }

        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { };
        }
        public override void load()
        {
            
        }

        public override void Sort()
        {
        }
        #endregion

        private void getWybranyKlient(Klienci klient)
        {
            Idklienta = klient.Idklienta;
            KlientNazwa = klient.Imie + " " + klient.Nazwisko;
        }
        private void generujcsv()
        {
            try
            {
                if (List == null)
                {
                    System.Windows.MessageBox.Show("Nie wygenerowano danych do zapisania");
                    throw new Exception("Nie wypełniono raportu");
                }
                string selectedPath = "C:\\";
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedPath = folderBrowserDialog.SelectedPath;
                }
                string data = DateTime.Now.ToString("yyyy-MM-dd");
                string csvFilePath = selectedPath + "\\raport_faktur_" + data + ".csv";
                using (var writer = new StreamWriter(csvFilePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(List);
                }
                System.Windows.MessageBox.Show("Zapisano plik w " + selectedPath + "\\raport_faktur" + data + ".csv");
            }
            catch
            {

            }
        }
        private void generujraport()
        {
            if(IdtypuFaktury == null && IdsposobuPlatnosci == null && Idklienta == null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd 
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );

            }
            if(IdsposobuPlatnosci != null && Idklienta != null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.IdsposobuPlatnosci == IdsposobuPlatnosci
                    && Faktura.Idklienta == Idklienta
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if(IdtypuFaktury != null && IdsposobuPlatnosci == null && Idklienta != null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.Idklienta == Idklienta
                    && Faktura.IdtypuFaktury == IdtypuFaktury
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if (IdtypuFaktury != null && IdsposobuPlatnosci != null && Idklienta == null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.IdsposobuPlatnosci == IdsposobuPlatnosci
                    && Faktura.IdtypuFaktury == IdtypuFaktury
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if (IdtypuFaktury == null && IdsposobuPlatnosci == null && Idklienta != null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.Idklienta == Idklienta
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if (IdtypuFaktury == null && IdsposobuPlatnosci != null && Idklienta == null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.IdsposobuPlatnosci == IdsposobuPlatnosci
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if (IdtypuFaktury != null && IdsposobuPlatnosci == null && Idklienta == null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    && Faktura.IdtypuFaktury == IdtypuFaktury
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
            if (IdtypuFaktury == null && IdsposobuPlatnosci == null && Idklienta == null)
            {
                List = new ObservableCollection<FakturaForView>
                (
                    from Faktura in projektEntities.Fakturas
                    where Faktura.DataWystawienia >= DataWystawieniaOd
                    && Faktura.DataWystawienia <= DataWystawieniaDo
                    && Faktura.TerminPlatnosci >= TerminPlatnosciOd
                    && Faktura.TerminPlatnosci <= TerminPlatnosciDo
                    select new FakturaForView
                    {
                        IdFaktury = Faktura.Idfaktury,
                        Numer = Faktura.Numer,
                        DataWystawienia = Faktura.DataWystawienia,
                        TerminPlatnosci = Faktura.TerminPlatnosci,
                        Imie = Faktura.IdklientaNavigation.Imie,
                        Nazwisko = Faktura.IdklientaNavigation.Nazwisko,
                        Adres = Faktura.IdklientaNavigation.Ulica + " " + Faktura.IdklientaNavigation.NrDomu + "/" + Faktura.IdklientaNavigation.NrLokalu + " " + Faktura.IdklientaNavigation.KodPocztowy + " " + Faktura.IdklientaNavigation.Miejscowosc,
                        Email = Faktura.IdklientaNavigation.Email,
                        Telefon = Faktura.IdklientaNavigation.Telefon,
                        NazwaSposobuPlatnosci = Faktura.IdsposobuPlatnosciNavigation.Nazwa,
                        TypFaktury = Faktura.IdtypuFakturyNavigation.Nazwa + " / " + Faktura.IdtypuFakturyNavigation.Skrot
                    }
                );
            }
        }
    }
}
