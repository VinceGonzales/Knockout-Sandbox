using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xolartek.Web.Models
{
    public class ViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public Gender Sex { get; set; }
    }
    public enum Gender
    {
        male, female
    }
}