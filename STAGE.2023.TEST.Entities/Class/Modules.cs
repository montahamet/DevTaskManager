using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities.Class
{
    public class Modules : List<Module>
    {
        public Modules() : base() { }
        public Modules(int capacity) : base(capacity) { }
        public Modules(IEnumerable<Module> collection) : base(collection) { }
    }
}
