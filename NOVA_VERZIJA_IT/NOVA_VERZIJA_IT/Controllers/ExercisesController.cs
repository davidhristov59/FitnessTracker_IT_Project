using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NOVA_VERZIJA_IT.Models;

namespace NOVA_VERZIJA_IT.Controllers
{
    public class ExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exercises

        //filter by muscle group AND filter both at the same time 
        /*
      
         * public ActionResult Index(int page = 1, string search = "", string category = "", List<string> muscleGroups = null)
        {
            int pageSize = 9;

            var exerciseQuery = db.Exercises.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                exerciseQuery = exerciseQuery.Where(e => e.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(category))
            {
                exerciseQuery = exerciseQuery.Where(e => e.Category == category);
            }


            var exercises = exerciseQuery.ToList();


            if (muscleGroups != null && muscleGroups.Any())
            {
                exercises = exercises.Where(e => e.muscleGroups != null && e.muscleGroups.Any(mg => muscleGroups.Contains(mg))).ToList();
            }

            var paginated_exercises = exercises
                              .OrderBy(e => e.Category) // or another sorting criterion
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();

            var totalExercises = exercises.Count();

            var totalPages = (int)Math.Ceiling((double)totalExercises / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentMuscleGroups = muscleGroups;

            return View(paginated_exercises);
        }
        */
        
        

        //FILTER BY CATEGORY
        public ActionResult Index(int page = 1, string search = "", string category = "", List<string> muscleGroups = null)
        {
            int pageSize = 9;

            var exerciseQuery = db.Exercises.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                exerciseQuery = exerciseQuery.Where(e => e.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(category))
            {
                exerciseQuery = exerciseQuery.Where(e => e.Category == category);
            }

            if (muscleGroups != null && muscleGroups.Any())
            {
                // Filters exercises where any of their muscle groups match any in the selected list
                exerciseQuery = exerciseQuery.Where(e => e.muscleGroups.Any(mg => muscleGroups.Contains(mg)));
            }


            //do tuka

            var exercises = db.Exercises
                               .Where(e => (string.IsNullOrEmpty(search) || e.Name.Contains(search)) && (string.IsNullOrEmpty(category) || e.Category == category))
                               .OrderBy(e => e.Category) // or another sorting criterion
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            var totalExercises = db.Exercises
                           .Count(e => (string.IsNullOrEmpty(search) || e.Name.Contains(search)) &&
                                       (string.IsNullOrEmpty(category) || e.Category == category));

            var totalPages = (int)Math.Ceiling((double)totalExercises / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentMuscleGroups = muscleGroups;

            return View(exercises);
        }
        


        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Category,Description,VideoUrl,muscleGroups")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
               
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Category,Description,VideoUrl,muscleGroups")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ExerciseName = exercise.Name;

                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);

           
                db.Exercises.Remove(exercise);
                db.SaveChanges();
            

            return RedirectToAction("Index");
        }


        public ActionResult addNewWorkout(int id)
        {
            /*
            var model = new WorkoutExercisePlans();

            model.exerciseID = id;
            model.Exercise = db.Exercises.Find(id);
            model.WorkoutPlans = db.WorkoutPlans.ToList();

            return View(model);
            */

        var exercise = db.Exercises.Find(id);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            ViewBag.ExerciseName = exercise.Name;


            var model = new WorkoutExercisePlans
            {
                      exerciseID = exercise.ID,
                   // exerciseID = id,
                    WorkoutPlans = db.WorkoutPlans.Select(wp => new SelectListItem
                {
                    Value = wp.ID.ToString(),
                    Text = wp.Title
                }).ToList()
            };
            
            return View(model);

        }



        //[HttpPost]
        //public ActionResult addNewWorkout(WorkoutExercisePlans model)
        //{
        //    /*
        //    var workoutPlan = db.WorkoutPlans.Find(model.workoutPlanID);
        //    var exercise = db.Exercises.Find(model.exerciseID);

        //    exercise.WorkoutPlans.Add(workoutPlan);
        //    db.SaveChanges();

        //    return View("Details", exercise);
        //    */

        //    var exercise = db.Exercises.Find(model.exerciseID);

        //    if (exercise != null)
        //    {
        //        // Clear existing workout plans
        //        exercise.WorkoutPlans.Clear();

        //        // Add new workout plans
        //        foreach (var planId in model.selectedWorkoutPlanIDs)
        //        {
        //            var plan = db.WorkoutPlans.Find(planId);
        //            if (plan != null)
        //            {
        //                exercise.WorkoutPlans.Add(plan);

        //            }
        //        }

        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Index");

        //}


        [HttpPost]
        public ActionResult addNewWorkout(WorkoutExercisePlans model)
        {
            var exercise = db.Exercises.Find(model.exerciseID);

            if (exercise != null)
            {
                foreach (var planId in model.selectedWorkoutPlanIDs)
                {
                    var plan = db.WorkoutPlans.Find(planId);

                    if (plan != null)
                    {
                        exercise.WorkoutPlans.Add(plan);

                        if (!string.IsNullOrEmpty(model.DayOfWeek))
                        {
                            plan.WeeklyExercises.Add(new WeeklyExercise
                            {
                                ExerciseId = exercise.ID,
                                DayOfWeek = model.DayOfWeek,
                                Sets = model.Sets,
                                Reps = model.Reps
                            }); 
                        }
                    }
                }

                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = model.exerciseID });
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
