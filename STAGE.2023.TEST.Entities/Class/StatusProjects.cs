using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class StatusProjects : List<StatusProject>
    {
        public StatusProjects() : base() { }
        public StatusProjects(int capacity) : base(capacity) { }
        public StatusProjects(IEnumerable<StatusProject> collection) : base(collection) { }
    }
}
