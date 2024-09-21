using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class DietAndNutrition
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Calories Goal")]
        public double CaloriesGoal { get; set; }

        [Display(Name="Total Calories")]
        public double totalCalories { get; set; }

        [Display(Name ="Remaining Calories")]
        public double caloriesRemaining { get; set; }

        public List<Food> BreakfastFoods { get; set; }
        public List<Food> LunchFoods { get; set; }
        public List<Food> DinnerFoods { get; set; }
        public List<Food> SnackFoods { get; set; }

    }
}