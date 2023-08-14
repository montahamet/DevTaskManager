using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.DataLayer
{
    public interface IUserRole
    {
        IEnumerable<Entities.UserRole> GetAll();
        Entities.UserRole GetOne(int userRoleId);
    }
}
