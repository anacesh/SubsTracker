namespace SubsTracker.Bot
{
    internal interface IBotManager
    {
        public bool StartBot();
        public void StopBot();
        public void RestartBot();

    }
}
