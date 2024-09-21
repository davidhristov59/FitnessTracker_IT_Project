using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class FitnessUserWorkoutsPlans
    {
        public int FitnessID { get; set; }
        public FitnessUser FitnessUser { get; set; }

        public int WPID { get; set; }

        public List<WorkoutPlan> WorkoutPlans { get; set; }
    }
}