namespace SubsTracker.Subs
{
    public class Sub : ISub
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Sum { get; set; }
        public string Link { get; set; } = string.Empty;
        public Sub(string name, string description, float sub, string link, string id)
        {
            this.Name = name;
            this.Description = description;
            this.Sum = sub;
            this.Link = link;
            this.Id = id;
        }

        private Sub() { }
    }
}
