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
