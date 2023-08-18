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
    public static class DevTask
    {
        private static IDevTask DevTask_DL;

        static DevTask()
        {
            DevTask_DL = new DevTaskDB();
        }

        public static  Entities.DevTasks GetAll(int ModID, int ProjID = -1)
        {
            return (DevTask_DL != null)
                   ? new Entities.DevTasks(DevTask_DL.GetAll(ModID, ProjID))
                   : null;
        }

        public static Entities.DevTask GetOneByID(int dev_task_id)
        {
            return (DevTask_DL != null)
                   ? DevTask_DL.GetOneByID(dev_task_id)
                   : null;
        }

        public static Entities.DevTask GetOneByProjectName(string project_name)
        {
            return (DevTask_DL != null)
                   ? DevTask_DL.GetOneByProjectName(project_name)
                   : null;
        }

        public static bool Add(Entities.DevTask devTask)
        {
            return (DevTask_DL != null)
                   ? DevTask_DL.Add(devTask)
                   : false;
        }

        public static bool Update(Entities.DevTask devTask)
        {
            return (DevTask_DL != null)
                   ? DevTask_DL.Update(devTask)
                   : false;
        }

        public static bool Remove(Entities.DevTask devTask)
        {
            return (DevTask_DL != null)
                   ? DevTask_DL.Remove(devTask)
                   : false;
        }
    }
}
