using System.Text.RegularExpressions;

namespace ChantemerleApi.Utilities
{
    /**
	 * @author Anthony Scheeres
	 */
    public class ValidateInputUtilities
    {


        /**
	 * @author Anthony Scheeres
	 */
        internal bool isNullOrEmty(string theStringToCheckIfItsNullorEmty)
        {
            return theStringToCheckIfItsNullorEmty.Length == 0;
        }

        /**
	 * @author Anthony Scheeres
	 */
        internal bool isNumeric(string s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }

        /**
	 * @author Anthony Scheeres
	 */
        internal bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
