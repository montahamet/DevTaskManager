using Org.BouncyCastle.Crypto;
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
    public static class Project
{
        private static IProject Project_DL;

        static Project()
        {
            Project_DL = new ProjectDB();
        }

        public static Entities.Projects GetAll()
        {
            return (Project_DL != null)
                   ? new Entities.Projects(Project_DL.GetAll())
                   : null;
        }

        public static Entities.Project Getone(int id_project)
        {
            return (Project_DL != null)
                   ? Project_DL.Getone(id_project)
                   : null;
        }

        public static bool Add(Entities.Project project)
        {
            return (Project_DL != null)
                   ? Project_DL.Add(project)
                   : false;
        }

        public static bool Update(Entities.Project project)
        {
            return (Project_DL != null)
                   ? Project_DL.Update(project)
                   : false;
        }

        public static bool Remove(Entities.Project project)
        {
            return (Project_DL != null)
                   ? Project_DL.Remove(project)
                   : false;
        }
    }
}
