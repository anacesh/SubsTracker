using SubsTracker.Subs;
using SubsTracker.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Users
{
    internal class UserManager
    {
        private static UserManager instance;
        public static UserManager Instance()
        {
            if (instance == null)
                instance = new UserManager();
            return instance;
        }
        private UserManager() { }

        public bool CreateNewUser(string username, string password, long id, bool isAdmin = false)
        {
            try
            {
                User user = new User(username, id, isAdmin);
                return true;
            }
            catch (Exception ex)
            {
                TrackExceptions.TrackException("Не удалось создать нового пользователя");
                return false;
            }
        }
/*        public IUser FindUserById(long id)
        {
            // TO DO
        }
        public IUser GetAdmin(long id)
        {
            // TO DO
        }
        public Sub[] GetAllUserSubs(IUser user)
        {
            // TO DO
        }*/
    }
}
