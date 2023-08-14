using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class TypeDevs : List<TypeDev>
    {
        public TypeDevs() : base() { }
        public TypeDevs(int capacity) : base(capacity) { }
        public TypeDevs(IEnumerable<TypeDev> collection) : base(collection) { }
    }
}
