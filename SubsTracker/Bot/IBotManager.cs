using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Bot
{
    internal interface IBotManager
    {
        public bool StartBot();
        public void StopBot();
        public void RestartBot();

    }
}
