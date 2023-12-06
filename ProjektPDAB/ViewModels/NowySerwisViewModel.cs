using ProjektPDAB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    internal class NowySerwisViewModel : JedenViewModel<Serwisy>
    {
        #region Konstruktor
        public NowySerwisViewModel() : base("Serwisy")
        {
            item = new Serwisy();
        }
        #endregion
        #region dane
        public DateTime? KiedyDodal
        {
            get
            {
                return item.KiedyDodal;
            }
            set
            {
                if (item.KiedyDodal != value)
                {
                    item.KiedyDodal = value;
                    OnPropertyChanged(() => KiedyDodal);
                }
            }
        }
        public int ID
        {
            get
            {
                return item.Idserwisu;
            }
        }
        public string NazwaSerwisu
        {
            get
            {
                return item.NazwaSerwisu;
            }
            set
            {
                if (item.NazwaSerwisu != value)
                {
                    item.NazwaSerwisu = value;
                    OnPropertyChanged(() => NazwaSerwisu);
                }
            }
        }
        public string Kontakt
        {
            get
            {
                return item.Kontakt;
            }
            set
            {
                if (item.Kontakt != value)
                {
                    item.Kontakt = value;
                    OnPropertyChanged(() => Kontakt);
                }
            }
        }
        public string Adres
        {
            get
            {
                return item.Adres;
            }
            set
            {
                if (item.Adres != value)
                {
                    item.Adres = value;
                    OnPropertyChanged(() => Adres);
                }
            }
        }
        #endregion
    }
}
