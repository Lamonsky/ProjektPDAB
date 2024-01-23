using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ProjektPDAB.Validators
{
    public static class StringValidator
    {
        public static string ValidateFirstLetterUp(this string value)
        {
            var result = string.Empty;
            try
            {
                if (!char.IsUpper(value, 0))
                {
                    result = "Rozpocznij dużą literą.";
                }
            }
            catch (Exception e){ }
            return result;
        }
        public static string NIPPeselValidator(this string value)
        {
            var result = string.Empty;
            try
            {
                if (value != null)
                {

                    if ((value.Length != 10 || value.Length != 11) && value.All(char.IsDigit))
                    {
                        result = "NIP powinien składać się z 10 cyfr, natomiast PESEL z 11 cyfr";
                    }
                }
            }
            catch (Exception e) { }
            return result;
        }
    }
}
