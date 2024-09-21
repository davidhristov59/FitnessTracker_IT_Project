using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class WeeklyExercise
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public string DayOfWeek { get; set; }
        public virtual Exercise Exercise { get; set; }

        [Required]
        public int WorkoutPlanID { get; set; }

        [ForeignKey("WorkoutPlanID")]
        public virtual WorkoutPlan WorkoutPlan { get; set; }

        //DODADENO 
        [Required]
        public int Sets { get; set; }
        
        [Required]
        public int Reps { get; set; }
    }
}