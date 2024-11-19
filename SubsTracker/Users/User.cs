using SubsTracker.Subs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Users
{
    internal class User
    {
        public bool IsAdmin { get; }
        public string UserName { get; }
        public string? Password { get; }
        public long id { get; }
        private ISub[] subs;

        public User(string username, long id, bool isAdmin)
        {
            this.UserName = username;
            this.id = id;
            this.IsAdmin = isAdmin;
        }

        public ISub[] GetSubs()
        {
            return subs;
        }
    }
}
