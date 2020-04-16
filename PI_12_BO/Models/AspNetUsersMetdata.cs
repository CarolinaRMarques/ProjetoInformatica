using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    public partial class AspNetUsersMetdata
    {
        public string Id { get; set; }
        [Display(Name="Email")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Display(Name="Utilizador")]
        public string UserName { get; set; }
        [Display(Name="Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [Display(Name="Género")]
        public string Gender { get; set; }
        [Display(Name="Nome Completo")]
        public string FullName { get; set; }
    }
}