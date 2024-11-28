namespace SubsTracker.Subs
{
    internal class SubManager
    {
        private static SubManager _instance;
        public static SubManager Instance()
        {
            if (_instance == null)
                _instance = new SubManager();
            return _instance;
        }

        private SubManager()
        { }

/*        public ISub[] GetAllUserSubs(long userId)
        {
            IUser user = UserManager.GetInstance().FindUserById(userId);
            return UserManager.GetInstance().GetAllUserSubs(user);
        }*/
    }
}
