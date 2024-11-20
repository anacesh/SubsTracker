using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubsTracker.Users;

namespace SubsTracker.Logs
{
    class TrackExceptions
    {
        public static void TrackException(string ex)
        {
            Console.WriteLine($"ex: {ex}, datetime: {System.DateTime.Now}");
        }
    }
}
