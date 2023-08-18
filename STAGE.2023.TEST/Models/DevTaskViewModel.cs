using Microsoft.AspNetCore.Http;
using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace STAGE._2023.TEST.Models
{
    public class DevTaskViewModel
    {
        public Entities.DevTasks DevTasks { get; set; }

        public Entities.DevTask DevTask { get; set; }
        public Project Project { get; set; }
        public Projects Projects { get; set; }
        public Entities.TypeDev TypeDev { get; set; }
        public Entities.TypeDevs TypeDevs { get; set; }
        public Entities.PriorityDev PriorityDev { get; set; }
        public Entities.PriorityDevs PriorityDevs { get; set; }
        public Entities.StatusDev StatusDev { get; set; }
        public Entities.StatusDevs StatusDevs { get; set; }
        public Entities.Users Users { get; set; }
        public Entities.User user { get; set; }
        public int dev_task_id { get; set; }
        public int id_project { get; set; }
        public int id_TypeDev { get; set; }
        public string details { get; set; }
        public string source { get; set; }
        public string posting_date { get; set; }
        public string posted_by { get; set; }
        public string due_date { get; set; }
        public int id_PriorityDev { get; set; }
        public int id_StatusDev { get; set; }
        public int id_user { get; set; }
        public string notes { get; set; }


    }
}
