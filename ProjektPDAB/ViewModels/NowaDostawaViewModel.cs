using ProjektPDAB.Models.Entities;
using ProjektPDAB.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.ViewModels
{
    class NowaDostawaViewModel : JedenViewModel<Dostawy>
    {
        #region Konstruktor
        public NowaDostawaViewModel() : base("Dostawy")
        {
            item = new Dostawy();
        }
        #endregion
        #region Dane
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
        public int IdDostawy { get; }
        public DateTime? DataDostawy
        {
            get
            {
                return item.DataDostawy;
            }
            set
            {
                if (item.DataDostawy != value)
                {
                    item.DataDostawy = value;
                    OnPropertyChanged(() => DataDostawy);
                }
            }
        }
        public string? StatusDostawy
        {
            get
            {
                return item.StatusDostawy;
            }
            set
            {
                if (item.StatusDostawy != value)
                {
                    item.StatusDostawy = value;
                    OnPropertyChanged(() => StatusDostawy);
                }
            }
        }
        public int? Iddostawcy
        {
            get
            {
                return item.Iddostawcy;
            }
            set
            {
                if (item.Iddostawcy != value)
                {
                    item.Iddostawcy = value;
                    OnPropertyChanged(() => Iddostawcy);
                }
            }
        }
        public IQueryable<Dostawcy> DostawcyComboBoxItemsOneArgument
        {
            get
            {
                return (
                    from NazwaDostawcy in projektEntities.Dostawcies
                    select NazwaDostawcy
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> DostawcyComboBoxItemsMultipleArguments
        {
            get
            {
                return (
                    from Dostawcy in projektEntities.Dostawcies
                    select new KeyAndValue
                    {
                        Key = Dostawcy.Iddostawcy,
                        Value = Dostawcy.NazwaDostawcy + " " + Dostawcy.NumerTelefonu + "\\" + Dostawcy.Email
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? Idproduktu
        {
            get
            {
                return item.Idproduktu;
            }
            set
            {
                if (item.Idproduktu != value)
                {
                    item.Idproduktu = value;
                    OnPropertyChanged(() => Idproduktu);
                }
            }
        }
        public IQueryable<Produkty> ProduktyComboBoxItemsOneArgument
        {
            get
            {
                return (
                    from Nazwa in projektEntities.Produkties
                    select Nazwa
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> ProduktyComboBoxItemsMultipleArguments
        {
            get
            {
                return (
                    from Produkty in projektEntities.Produkties
                    select new KeyAndValue
                    {
                        Key = Produkty.Idproduktu,
                        Value = Produkty.Nazwa + " " + Produkty.Cena
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
    }
}
