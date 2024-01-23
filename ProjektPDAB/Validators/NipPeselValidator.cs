using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPDAB.Validators
{
    public class NipPeselValidator
    {
        public static bool PeselValidator(string value, out string message)
        {
            var result = true;
            message = "";
            if (value.Length != 11)
            {
                message = "Pesel powinien składać się z 11 cyfr";
                result = false;
            }
            return result;
        }
        public static bool NIPValidator(string value, out string message)
        {
            var result = true;
            message = "";
            if (value.Length != 10)
            {
                message = "NIP powinien składać się z 10 cyfr";
                result = false;
            }
            return result;
        }
    }
}
