using Microsoft.AspNetCore.Http;
using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Models
{
    public class ModuleViewModel
    {
        public Entities.Projects Projects { get; set; }

        public Entities.DevTasks DevTasks { get; set; }

        public Entities.Module Module { get; set; }



        [Required(ErrorMessage = "Complete this field")]
        public int module_id { get; set; }

        [Required(ErrorMessage = "Complete this field")]
        public string module_name { get; set; }


    }
}
