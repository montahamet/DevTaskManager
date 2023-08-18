using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class Project
    {
        public object id_StatusProject;
        public object id_module;
        

        public Project()
        {
            StatusProject = new StatusProject();
            Module = new Module();
            User = new User();
        }
        public int id_project { get; set; }
        public string project_name { get; set; }
        public int module_id { get; set; }
        public string project_version { get; set; } 
        public string project_description { get; set;}
        public User User { get; set; }
        public decimal project_estimated_budget { get; set; }
        public decimal project_total_amount { get; set; }
        public string project_estimated_duration { get; set; }
        public StatusProject StatusProject { get; set; }
        public object StatusProject_name { get; set; }
        public Module Module { get; set; }
    }
}
