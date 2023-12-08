using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class NowaFakturaViewModel : JedenViewModel<Faktura>
    {
        #region Kontruktor
        public NowaFakturaViewModel():base("Faktura"){
            item = new Faktura();
        }
        #endregion
        #region Dane
        public int Idfaktury { get; }
        public string? Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? Idklienta
        {
            get
            {
                return item.Idklienta;
            }
            set
            {
                if (item.Idklienta != value)
                {
                    item.Idklienta = value;
                    OnPropertyChanged(() => Idklienta);
                }
            }
        }
        public int? IdsposobuPlatnosci
        {
            get
            {
                return item.IdsposobuPlatnosci;
            }
            set
            {
                if (item.IdsposobuPlatnosci != value)
                {
                    item.IdsposobuPlatnosci = value;
                    OnPropertyChanged(() => IdsposobuPlatnosci);
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
        public IQueryable<KeyAndValue> KlientComboBoxItems
        {
            get
            {
                return (
                    from Klienci in projektEntities.Kliencis
                    select new KeyAndValue
                    {
                        Key = Klienci.Idklienta,
                        Value = Klienci.Imie + " " + Klienci.Nazwisko
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
