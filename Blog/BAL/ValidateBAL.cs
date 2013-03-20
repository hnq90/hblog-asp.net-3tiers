using System.Text.RegularExpressions;
using Commons;
using DAL;

namespace BAL
{
    public class ValidateBAL
    {
        public int ValidLogin(string user, string pass)
        {
            return (UserDAL.ValidUser(user, pass));
        }

        public bool ValidNewPass(string newpass, string renewpass)
        {
            return renewpass.Length != 0 && newpass.Length != 0 && newpass.Equals(renewpass);
        }

        public bool ValidUsername(string username)
        {
            return (Regex.IsMatch(username, BlogCommons._username_pattern));
        }

        public bool ValidPassword(string password)
        {
            return (Regex.IsMatch(password, BlogCommons._password_pattern));
        }

        public bool ValidEmail(string email)
        {
            return (Regex.IsMatch(email, BlogCommons._email_pattern));
        }
    }
}