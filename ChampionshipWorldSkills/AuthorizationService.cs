using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionshipWorldSkills.DataSet;

namespace ChampionshipWorldSkills
{
    static class AuthorizationService
    {
        public static User LoginedUser { get; private set; }

        public static void LoginUser(string pin, string password)
        {
            try
            {
                LoginedUser = new User(pin, password);
            }
            catch (RecordNotFoundException ex)
            {
                throw ex;
            }
        }

        public static void LogoutUser()
        {
            LoginedUser = null;
        }
    }
}
