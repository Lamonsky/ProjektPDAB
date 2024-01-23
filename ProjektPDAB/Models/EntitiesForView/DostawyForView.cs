using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.Models.EntitiesForView
{
    public class DostawyForView
    {
        #region Dane
        public int IdDostawy{ get; set; }
        public string NazwaDostawcy{ get; set; }
        public DateTime? DataDostawy { get; set; }
        public string StatusDostawy { get; set; }
        public string NazwaProduktu { get; set; }
        public decimal? CenaProduktu { get; set; }    
        public int? Ilosc { get; set; }
        #endregion
    }
}
