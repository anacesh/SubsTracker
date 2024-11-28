namespace SubsTracker.Tracker
{
    static class TrackExceptions
    {
        public static bool isDebugging = true;
        public static void TrackException(string ex)
        {
            Console.WriteLine($"ex: {ex}, datetime: {System.DateTime.Now}");
        }

        public static void SendDebugMessage(string ex)
        {
            if (isDebugging) Console.WriteLine($"event: {ex}, datetime: {System.DateTime.Now}");
        }

        public static void SendBotMessage(string ex)
        {
            Console.WriteLine($"bot: {ex}, datetime: {System.DateTime.Now}");
        }


    }
}
