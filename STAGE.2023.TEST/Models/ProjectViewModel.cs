using Microsoft.AspNetCore.Http;
using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Models
{
    public class ProjectViewModel
    {
        public Entities.Projects Projects { get; set; }

        public Entities.Project Project { get; set; }
        public Entities.StatusProject StatusProject { get; set; }
        public Entities.StatusProjects StatusProjects { get; set; } 
        public Entities.Module Module { get; set; }
        public Entities.Modules Modules { get; set; }
        public Entities.Users Users { get; set; }


        public int id_project { get; set; }

        [Required(ErrorMessage = "Complete this field")]
        public string project_name { get; set; }


        [Required(ErrorMessage = "Complete this field")]
        public int module_id { get; set; }


        [Required(ErrorMessage = "Complete this field")]
        public string project_version { get; set; }

        [Required(ErrorMessage = "Complete this field")]
        public string project_description { get; set; }

        [Required]
        public int id_user { get; set; }

        [Required]
        public decimal project_estimated_budget { get; set; }

        [Required]
        public decimal project_total_amount { get; set; }

        [Required]
        public string project_estimated_duration { get; set; }

        [Required]
        public int id_StatusProject { get; set; }
     
        public string StatusProject_name { get; set; }
        public string module_name { get; set; }
        public string FullName { get; set; }
    }
}










