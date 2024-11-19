using SubsTracker.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Subs
{
    internal class SubManager
    {
        private static SubManager _instance;
        public static SubManager GetInstance()
        {
            if (_instance == null)
                _instance = new SubManager();
            return _instance;
        }

        private SubManager()
        { }

/*        public ISub[] GetAllUserSubs(long userId)
        {
            IUser user = UserManager.GetInstance().FindUserById(userId);
            return UserManager.GetInstance().GetAllUserSubs(user);
        }*/
    }
}
