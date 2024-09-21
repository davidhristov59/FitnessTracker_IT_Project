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
    public class WorkoutPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkoutPlans
        public ActionResult Index()
        {
            return View(db.WorkoutPlans.ToList());
        }

        // GET: WorkoutPlans/Details/5
        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutPlan workoutPlan = db.WorkoutPlans.Find(id);
            if (workoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workoutPlan);
        }

        // GET: WorkoutPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkoutPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ImageURL")] WorkoutPlan workoutPlan)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutPlans.Add(workoutPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workoutPlan);
        }

        // GET: WorkoutPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutPlan workoutPlan = db.WorkoutPlans.Find(id);
            if (workoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workoutPlan);
        }

        // POST: WorkoutPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ImageURL")] WorkoutPlan workoutPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workoutPlan);
        }

        // GET: WorkoutPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutPlan workoutPlan = db.WorkoutPlans.Find(id);
            if (workoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workoutPlan);
        }

        // POST: WorkoutPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutPlan workoutPlan = db.WorkoutPlans.Find(id);
            db.WorkoutPlans.Remove(workoutPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //ne treba metodov
        [HttpPost]
        public ActionResult AddExerciseToDayOfWeek(int workoutPlanId, string dayOfWeek, string name, string description)
        {
            var exercise = new Exercise
            {
                Name = name,
                DayOfWeek = dayOfWeek,
                Description = description
            };

            db.Exercises.Add(exercise);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = workoutPlanId });

        }
        

        

        public ActionResult addNewExercise(int id)
        {
            var model = new WorkoutPlanExercises();

            model.workoutPlanID = id;
            model.WorkoutPlan = db.WorkoutPlans.Find(id);
            model.Exercises = db.Exercises.ToList();

            return View(model);

        }

        [HttpPost]
        public ActionResult addNewExercise(WorkoutPlanExercises model)
        {
            

            var workoutPlan = db.WorkoutPlans.Find(model.workoutPlanID);
            var exercise = db.Exercises.Find(model.exerciseID);

            workoutPlan.Exercises.Add(exercise);
            db.SaveChanges();

            return View("Details", workoutPlan);
            
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
