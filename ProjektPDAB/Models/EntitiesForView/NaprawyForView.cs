using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.Models.EntitiesForView
{
    public class NaprawyForView
    {
        #region Dane
        public int Idnaprawy { get; set; }
        public DateTime? DataNaprawy { get; set; }
        public string? StatusNaprawy { get; set; }
        //Zamiast IDSerwisu
        public string? NazwaSerwisu { get; set; }
        public string? Kontakt { get; set; }
        public string? Adres { get; set; }

        //Zamiast IDProduktu
        public string? Nazwa { get; set; }
        //Zamiast IDKategorii z Produktu
        public string? NazwaKategorii { get; set; }

        #endregion
    }
}
