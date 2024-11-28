using SubsTracker.Subs;

namespace SubsTracker.Users
{
    public class User
    {
        public string Id { get; set; }
        public bool IsAdmin { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; } = string.Empty;
        public ICollection<Sub> Subs { get; set; } = new List<Sub>();

        public User(string? username, string id, bool isAdmin = false)
        {
            this.UserName = username;
            this.Id = id;
            this.IsAdmin = isAdmin;
        }

        private User() { }
    }
}
