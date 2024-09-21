using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class WorkoutPlanExercises
    {
        public int workoutPlanID { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }

        public int exerciseID { get; set; }
        public List<Exercise> Exercises { get; set; }


        [Display(Name ="Day of Week")]
        public string dayOfWeek { get; set; }
    }
}