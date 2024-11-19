using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Subs
{
    internal class Sub : ISub
    {
        public int id {  get; set; }
        public string Name { get; }
        public string Description { get; }
        public float Sum { get; }
        public string Link { get; }
        public Sub(string name, string description, float sub, string link, int id)
        {
            this.Name = name;
            this.Description = description;
            this.Sum = sub;
            this.Link = link;
            this.id = id;
        }
    }
}
