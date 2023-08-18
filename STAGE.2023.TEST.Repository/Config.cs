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

        #region TypeDevs
        public static Entities.TypeDevs GetAllTypeDevs()
        {
            return (Config_DL != null)
                   ? new Entities.TypeDevs(Config_DL.GetAllTypeDevs())
                   : null;
        }
        public static Entities.TypeDev TypeDevGetOne(int id_TypeDev)
        {
            return (Config_DL != null)
                   ? Config_DL.TypeDevGetOne(id_TypeDev)
                   : null;
        }
        public static bool TypeDevAdd(Entities.TypeDev typedev)
        {
            return (Config_DL != null)
                   ? Config_DL.TypeDevAdd(typedev)
                   : false;
        }
        public static bool TypeDevUpdate(Entities.TypeDev typedev)
        {
            return (Config_DL != null)
                   ? Config_DL.TypeDevUpdate(typedev)
                   : false;
        }
        public static bool TypeDevRemove(Entities.TypeDev typedev)
        {
            return (Config_DL != null)
                   ? Config_DL.TypeDevRemove(typedev)
                   : false;
        }


        #endregion

        #region PriorityDev
        public static Entities.PriorityDevs GetAllPriorityDevs()
        {
            return (Config_DL != null)
                   ? new Entities.PriorityDevs(Config_DL.GetAllPriorityDevs())
                   : null;
        }
        public static Entities.PriorityDev PriorityDevGetOne(int id_PriorityDev)
        {
            return (Config_DL != null)
                   ? Config_DL.PriorityDevGetOne(id_PriorityDev)
                   : null;
        }
        public static bool PriorityDevAdd(PriorityDev prioritydev)
        {
            return (Config_DL != null)
                   ? Config_DL.PriorityDevAdd(prioritydev)
                   : false;
        }
        public static bool PriorityDevUpdate(PriorityDev prioritydev)
        {
            return (Config_DL != null)
                   ? Config_DL.PriorityDevUpdate(prioritydev)
                   : false;
        }
        public static bool PriorityDevRemove(PriorityDev prioritydev)
        {
            return (Config_DL != null)
                   ? Config_DL.PriorityDevRemove(prioritydev)
                   : false;
        }

        #endregion

        #region StatusDev
        public static Entities.StatusDevs GetAllStatusDevs()
        {
            return (Config_DL != null)
                   ? new Entities.StatusDevs(Config_DL.GetAllStatusDevs())
                   : null;
        }
        public static Entities.StatusDev StatusDevGetOne(int id_StatusDev)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusDevGetOne(id_StatusDev)
                   : null;
        }
        public static bool StatusDevAdd(StatusDev statusdev)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusDevAdd(statusdev)
                   : false;
        }
        public static bool StatusDevUpdate(StatusDev statusdev)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusDevUpdate(statusdev)
                   : false;
        }
        public static bool StatusDevRemove(StatusDev statusdev)
        {
            return (Config_DL != null)
                   ? Config_DL.StatusDevRemove(statusdev)
                   : false;
        }



        #endregion
    }
}
