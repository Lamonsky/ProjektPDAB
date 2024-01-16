using Microsoft.Extensions.Primitives;
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
        public int Idserwisu
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
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }
        public string EMail
        {
            get
            {
                return item.Email;
            }
            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    OnPropertyChanged(() => EMail);
                }
            }
        }
        public int? Idadres
        {
            get
            {
                return item.Idadres;
            }
            set
            {
                if (item.Idadres != value)
                {
                    item.Idadres = value;
                    OnPropertyChanged(() => Idadres);
                }
            }
        }

        #endregion
    }
}
