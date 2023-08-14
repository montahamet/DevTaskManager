using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STAGE._2023.TEST.DataLayer;
using STAGE._2023.TEST.DataLayer.DB;
using STAGE._2023.TEST.Entities;

namespace STAGE._2023.TEST.Repository
{
    public static class UserRole
    {
        private static IUserRole UserRole_DL;

        static UserRole()
        {
            UserRole_DL = new UserRoleDB();
        }

        public static Entities.UserRoles GetAll()
        {
            return (UserRole_DL != null)
                   ? new Entities.UserRoles(UserRole_DL.GetAll())
                   : null;
        }
        public static Entities.UserRole GetOne(int userRoleId)
        {
            return (UserRole_DL != null)
                    ? UserRole_DL.GetOne(userRoleId)
                   : null;
        }

    }
}
