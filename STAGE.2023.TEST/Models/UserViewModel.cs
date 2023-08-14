using Microsoft.AspNetCore.Http;
using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace STAGE._2023.TEST.Models
{
    public class UserViewModel
    {
        public Entities.User User { get; set; }
        public Entities.UserRole UserRole { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ"), MaxLength(20)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string Login { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ"), MaxLength(8)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "veuillez compléter ce champ")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Role")]
        public int UserRoleId { get; set; }


        public string RoleName { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
