using SubsTracker.Subs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Bot
{
    class BotManager
    {
        private static BotManager _instance;
        public static BotManager GetInstance()
        {
            if (_instance == null)
                _instance = new BotManager();
            return _instance;
        }

        private BotManager()
        { }

        public bool StartBot()
        {
            Console.WriteLine("Bot started.");
            return true;
        }

        public void StopBot()
        {
            Console.WriteLine("Bot stopped.");
        }

        public void RestartBot()
        {
            StopBot();
            StartBot();
        }
    }
}
