/// <summary>
/// Defines the possible states a user can be in within the bot.
/// </summary>
namespace SubsTracker.Users
{
    /// <summary>
    /// Enum representing the various states of a user in the bot's workflow.
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// Represents a state where the user has not selected a specific state yet.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents a state where the user is currently in the main menu.
        /// </summary>
        InMenu = 1,

        /// <summary>
        /// Represents a state where the user is managing their subscriptions.
        /// </summary>
        InSubscriptions = 2,

        /// <summary>
        /// Represents a state where the user is in the process of adding a new subscription.
        /// </summary>
        AddingSubscription = 3,

        /// <summary>
        /// Represents a state where the user is seeking help.
        /// </summary>
        InHelp = 4,

        /// <summary>
        /// Represents a state where the user is viewing the admin menu.
        /// </summary>
        AdminViewMenu = 5,

        /// <summary>
        /// Represents a state where the admin is managing users.
        /// </summary>
        AdminManagingUsers = 6
    }
}
