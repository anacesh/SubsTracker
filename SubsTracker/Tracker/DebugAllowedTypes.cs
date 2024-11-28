namespace SubsTracker.Tracker
{
    /// <summary>
    /// Contains settings and allowed types for debugging.
    /// </summary>
    class DebugAllowedTypes
    {
        /// <summary>
        /// Dictionary that maps debugging message types to whether they are enabled.
        /// </summary>
        public static Dictionary<string, bool> allowedTypes = new Dictionary<string, bool>
        {
            { "event", true },
            { "new_user", true },
            { "new_message", false },
            { "user_info", true }
        };
    }
}
