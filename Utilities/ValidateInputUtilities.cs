using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public bool isNullOrEmty(string theStringToCheckIfItsNullorEmty)
        {
            return theStringToCheckIfItsNullorEmty.Length == 0;
        }

        /**
	 * @author Anthony Scheeres
	 */
        public bool isNumeric(string s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }

        /**
	 * @author Anthony Scheeres
	 */
        public bool IsValidEmail(string email)
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
