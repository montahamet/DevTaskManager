using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class UserRoles : List<UserRole>
    {
        public UserRoles() : base() { }
        public UserRoles(int capacity) : base(capacity) { }
        public UserRoles(IEnumerable<UserRole> collection) : base(collection) { }
    }
}
