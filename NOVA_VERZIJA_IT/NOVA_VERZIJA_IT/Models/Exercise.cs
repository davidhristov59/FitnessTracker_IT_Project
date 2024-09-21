using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NOVA_VERZIJA_IT.Models
{
    public class Exercise
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [Display(Name="Video URL")]
        public string VideoUrl { get; set; }

        public string DayOfWeek { get; set; }
        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; }

        [Display(Name="Muscle Groups")]
        public string muscleGroupsJson { get; set; } // New property for database storage

        [Display(Name="Muscle Groups")]
        [NotMapped]
        public List<string> muscleGroups
        {
            get { return string.IsNullOrEmpty(muscleGroupsJson) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(muscleGroupsJson); }
            set { muscleGroupsJson = JsonConvert.SerializeObject(value); }
        }

        public Exercise()
        {
            WorkoutPlans = new List<WorkoutPlan>();
        }
    }
}