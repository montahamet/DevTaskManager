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
    public static class Config
{
        private static IConfig Config_DL;
        public static object StatusProjects;

        static Config()
        {
            Config_DL = new ConfigDB();
        }


        #region StatusProject

        public static Entities.StatusProjects GetAllStatusProject()
        {
            return (Config_DL != null)
                   ? new Entities.StatusProjects(Config_DL.GetAllStatusProject())
                   : null;
        }


        public static Entities.StatusProject StatusProjectGetOne(int id_StatusProject)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusProjectGetOne(id_StatusProject)
                   : null;
        }


        public static bool StatusProjectAdd(Entities.StatusProject status_p)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusProjectAdd(status_p)
                   : false;
        }

        public static bool StatusProjectUpdate(Entities.StatusProject status_p)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusProjectUpdate(status_p)
                   : false;
        }

        public static bool StatusProjectRemove(Entities.StatusProject status_p)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusProjectRemove(status_p)
                   : false;
        }

        #endregion
    }
}
