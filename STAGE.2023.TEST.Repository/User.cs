using STAGE._2023.TEST.DataLayer;
using STAGE._2023.TEST.DataLayer.DB;
using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Repository
{
    public static class User
    {
        private static IUser User_DL;

        static User()
        {
            User_DL = new UserDB();
        }

        public static Entities.Users GetAll()
        {
            return (User_DL != null)
                   ? new Entities.Users(User_DL.GetAll())
                   : null;
        }

        public static Entities.User GetOne(int userId)
        {
            return (User_DL != null)
                   ? User_DL.GetOne(userId)
                   : null;
        }

        public static Entities.User GetOneByLogin(string userLogin)
        {
            return (User_DL != null)
                   ? User_DL.GetOneByLogin(userLogin)
                   : null;
        }

        public static bool Add(Entities.User user)
        {
            return (User_DL != null)
                   ? User_DL.Add(user)
                   : false;
        }

        public static bool Update(Entities.User user)
        {
            return (User_DL != null)
                   ? User_DL.Update(user)
                   : false;
        }

        public static bool Remove(Entities.User user)
        {
            return (User_DL != null)
                   ? User_DL.Remove(user)
                   : false;
        }

    }
}
