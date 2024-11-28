/// <summary>
/// Provides methods for tracking exceptions and debugging messages in the application.
/// </summary>
namespace SubsTracker.Tracker
{
    /// <summary>
    /// Tracks and logs exceptions and debug messages based on configured settings.
    /// </summary>
    static class TrackExceptions
    {
        /// <summary>
        /// Indicates whether debugging is enabled.
        /// </summary>
        public static bool isDebugging = true;

        /// <summary>
        /// Tracks exceptions by logging them to the console.
        /// </summary> 
        /// <param name="ex">The exception message to log.</param>
        public static void TrackException(string ex)
        {
            Console.WriteLine($"ex: {ex}, datetime: {System.DateTime.Now}");
        }

        /// <summary>
        /// Sends debug messages to the console if debugging is enabled and the message type is allowed.
        /// </summary>
        /// <param name="ex">The debug message to log.</param>
        /// <param name="type">The type of debug message (default is "event").</param>
        public static void SendDebugMessage(string ex, string type = "event")
        {
            if (isDebugging && DebugAllowedTypes.allowedTypes.ContainsKey(type) && DebugAllowedTypes.allowedTypes[type])
                Console.WriteLine($"{type}: {ex}, datetime: {System.DateTime.Now}");
        }

        /// <summary>
        /// Sends a bot message to the console.
        /// </summary>
        /// <param name="ex">The bot message to log.</param>
        public static void SendBotMessage(string ex)
        {
            Console.WriteLine($"bot: {ex}, datetime: {System.DateTime.Now}");
        }


    }
}
