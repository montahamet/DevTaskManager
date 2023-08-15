using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class DevTasks : List<DevTask>
    {
        public DevTasks() : base() { }
        public DevTasks(int capacity) : base(capacity) { }
        public DevTasks(IEnumerable<DevTask> collection) : base(collection) { }
    }
}
