using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class Projects : List<Project>
    {
        public Projects() : base() { }
        public Projects(int capacity) : base(capacity) { }
        public Projects(IEnumerable<Project> collection) : base(collection) { }
    }
}
