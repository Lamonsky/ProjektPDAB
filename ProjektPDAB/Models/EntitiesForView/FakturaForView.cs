using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.Models.EntitiesForView
{
    public class FakturaForView
    {
        #region Dane
        public int IdFaktury { get; set; }
        public string? Numer { get; set; }
        public DateOnly? DataWystawienia { get; set; }
        public DateOnly? TerminPlatnosci { get; set; }
        //Zamiast IdKlienta
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
        //Zamiast IdSposobuPlatnosci
        public string? NazwaSposobuPlatnosci { get; set; }
        public string? TypFaktury { get; set; }
        #endregion
    }
}
