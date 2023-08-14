using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities.Class
{
    public class Module
    {
        public object id_project;
        public object id_TypeDev;
        public object id_PriorityDev;
        public object id_StatusDev;
        public Module()
        {
            User = new User();
            Project =new Project();
            TypeDev typeDev = new TypeDev();
            PriorityDev priorityDev = new PriorityDev();
            StatusDev statusDev = new StatusDev();
        }
        public string module_name { get; set; }
        public Project Project { get; set; }
        public TypeDev TypeDev { get; set; }
        public string module_details { get; set; }
        public string posting_date { get; set; }
        public string posted_by { get; set; }
        public string due_date { get; set; }
        public PriorityDev PriorityDev { get; set; }
        public StatusDev StatusDev { get; set; }
        public User User { get; set; }
        public string module_notes { get; set; }

    }
}
