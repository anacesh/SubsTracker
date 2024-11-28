using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Users
{
    public enum UserState
    {
        None = 0,
        InMenu = 1,
        InSubscriptions = 2,
        AddingSubscription = 3,
        InHelp = 4,
        AdminViewMenu = 5,
        AdminManagingUsers = 6
    }
}
