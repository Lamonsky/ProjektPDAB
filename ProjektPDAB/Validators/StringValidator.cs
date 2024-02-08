using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        public static string TelefonValidator(this string value)
        {
            var result = string.Empty;
            try
            {
                if (value != null)
                {

                    if ((value.Length != 9) || !value.All(char.IsDigit))
                    {
                        result = "Błędny format numeru telefonu, 9 cyfr";
                    }
                }
            }
            catch (Exception e) { }
            return result;
        }
        public static string EmailValidator(this string value)
        {
            var result = string.Empty;
            try
            {
                if (value != null)
                {
                    try
                    {
                        MailAddress mailAddress = new MailAddress(value);
                    }
                    catch (FormatException)
                    {
                        result = "Błędny format adresu e-mail";
                    }
                }
            }
            catch (Exception e) { }
            return result;
        }
    }
}
