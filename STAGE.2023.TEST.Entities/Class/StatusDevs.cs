using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class StatusDevs : List<StatusDev>
    {
        public StatusDevs() : base() { }
        public StatusDevs(int capacity) : base(capacity) { }
        public StatusDevs(IEnumerable<StatusDev> collection) : base(collection) { }
    }
}
