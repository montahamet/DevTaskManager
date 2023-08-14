using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class PriorityDevs : List<PriorityDev>
    {
        public PriorityDevs() : base() { }
        public PriorityDevs(int capacity) : base(capacity) { }
        public PriorityDevs(IEnumerable<PriorityDev> collection) : base(collection) { }
    }
}
