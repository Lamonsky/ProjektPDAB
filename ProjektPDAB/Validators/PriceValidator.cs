using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.Validators
{
    public class PriceValidator
    {
        public static string IsGreaterThanZero(int? value)
        {
            var result = string.Empty;
            if (value == null || value <= 0)
            {
                result = "Cena powinna być większa od 0";
            }
            return result;
        }
    }
}
