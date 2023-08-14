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

        
        public int id_project { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string project_name { get; set; }


        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string project_module { get; set; }


        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string project_version { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string project_description { get; set; }

        [Required]
        public string project_leader { get; set; }

        [Required]
        public decimal project_estimated_budget { get; set; }

        [Required]
        public decimal project_total_amount { get; set; }

        [Required]
        public string project_estimated_duration { get; set; }

        [Required]
        public int id_StatusProject { get; set; }
     
        public string StatusProject_name { get; set; }

    }
}










