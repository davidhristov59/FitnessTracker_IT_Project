using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOVA_VERZIJA_IT.Models
{
    public class WorkoutExercisePlans
    {
        //public int workoutPlanID { get; set; }
        public List<int> selectedWorkoutPlanIDs { get; set; }
        //public List<WorkoutPlan> WorkoutPlans { get; set; }

        public List<SelectListItem> WorkoutPlans { get; set; }

        //za ListBoxFor
        //public IEnumerable<SelectListItem> WorkoutPlans { get; set; }


        public int exerciseID { get; set; }

        [Display(Name = "Day of the Week")]
        public string DayOfWeek { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}