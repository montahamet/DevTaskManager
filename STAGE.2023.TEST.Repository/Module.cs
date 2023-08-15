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
    public static class Module
    {
        private static IModule Module_DL;

        static Module()
        {
            Module_DL = new ModuleDB();
        }

        public static Entities.Modules GetAll(int id_project = -1)
        {
            return (Module_DL != null)
                   ? new Entities.Modules(Module_DL.GetAll(id_project))
                   : null;
        }

        public static Entities.Module GetOneByID(int dev_task_id)
        {
            return (Module_DL != null)
                   ? Module_DL.GetOneByID(dev_task_id)
                   : null;
        }

        public static Entities.Module GetOneByName(string module_name)
        {
            return (Module_DL != null)
                   ? Module_DL.GetOneByName(module_name)
                   : null;
        }

        public static bool Add(Entities.Module module)
        {
            return (Module_DL != null)
                   ? Module_DL.Add(module)
                   : false;
        }

        public static bool Update(Entities.Module module)
        {
            return (Module_DL != null)
                   ? Module_DL.Update(module)
                   : false;
        }

        public static bool Remove(Entities.Module module)
        {
            return (Module_DL != null)
                   ? Module_DL.Remove(module)
                   : false;
        }
    }
}
