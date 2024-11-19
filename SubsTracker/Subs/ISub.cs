using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsTracker.Subs
{
    internal interface ISub
    {
        public string Name { get; }
        public string Description { get; }
        public float Sum { get; }
        public string Link { get; }
    }
}
