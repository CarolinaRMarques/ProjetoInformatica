using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    public class DTO_UserRole
    {
        [Key]
        [Display(Name = "Papel")]
        public string RoleId { get; set; }
        [Display(Name = "Utilizador")]
        public string UserId { get; set; }
    }
}