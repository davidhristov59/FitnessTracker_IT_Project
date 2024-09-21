using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Serving Size (grams)")]
        public int ServingSize { get; set; }

        [Display(Name = "Protein (grams)")]
        public double Protein { get; set; }

        [Display(Name = "Carbs (grams")]
        public double Carbs { get; set; }

        [Display(Name = "Fat (grams)")]
        public double Fats { get; set; }

        [Display(Name = "Calories")]
        public double Calories { get; set; }

        [Display(Name = "Meal Type")]
        public string MealType { get; set; }

        [Display(Name="Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name ="Ingredients")]
        public string Ingredients { get; set; }
    }
}