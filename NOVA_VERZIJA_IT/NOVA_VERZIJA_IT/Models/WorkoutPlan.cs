using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class WorkoutPlan
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name ="Image URL")]
        public string ImageURL { get; set; }
        public virtual ICollection<FitnessUser> FitnessUsers { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public WorkoutPlan()
        {
            Exercises = new List<Exercise>();
           FitnessUsers = new List<FitnessUser>();
        }

        public virtual ICollection<WeeklyExercise> WeeklyExercises { get; set; }
    }
}