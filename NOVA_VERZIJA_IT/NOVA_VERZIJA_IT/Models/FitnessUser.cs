using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class FitnessUser 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string contactNumber { get; set; }

        [Display(Name = "Profile Image")]
        public IFormFile Image { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "Membership Created")]
        public DateTime membershipCreated { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }


        //dodadeno od RegisterViewModel
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; }

        public FitnessUser()
        {
            WorkoutPlans = new List<WorkoutPlan>();
        }
    }
}