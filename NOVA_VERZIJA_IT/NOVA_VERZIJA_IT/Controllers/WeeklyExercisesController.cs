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
    public class WeeklyExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //dodadeni 2ta metoda
        public ActionResult AddExercise(int workoutPlanId)
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            var weeklyExercise = new WeeklyExercise { WorkoutPlanID = workoutPlanId };

            return View(weeklyExercise);
        }

        // POST: WeeklyExercises/AddExercise
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExercise([Bind(Include = "ID,DayOfWeek,Sets,Reps,ExerciseID,WorkoutPlanID")] WeeklyExercise weeklyExercise)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyExercises.Add(weeklyExercise);
                db.SaveChanges();
                return RedirectToAction("Details", "WorkoutPlans", new { id = weeklyExercise.WorkoutPlanID });
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", weeklyExercise.Exercise);
            return View(weeklyExercise);
        }


        // GET: WeeklyExercises
        public ActionResult Index()
        {
            var weeklyExercises = db.WeeklyExercises.Include(w => w.Exercise);
            return View(weeklyExercises.ToList());
        }

        // GET: WeeklyExercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyExercise weeklyExercise = db.WeeklyExercises.Find(id);
            if (weeklyExercise == null)
            {
                return HttpNotFound();
            }
            return View(weeklyExercise);
        }

        // GET: WeeklyExercises/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ID", "Name");
            return View();
        }

        // POST: WeeklyExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ExerciseId,DayOfWeek,Sets,Reps")] WeeklyExercise weeklyExercise)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyExercises.Add(weeklyExercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseId = new SelectList(db.Exercises, "ID", "Name", weeklyExercise.ExerciseId);
            return View(weeklyExercise);
        }

        // GET: WeeklyExercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyExercise weeklyExercise = db.WeeklyExercises.Find(id);
            if (weeklyExercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ID", "Name", weeklyExercise.ExerciseId);
            return View(weeklyExercise);
        }

        // POST: WeeklyExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ExerciseId,DayOfWeek,Sets,Reps")] WeeklyExercise weeklyExercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyExercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseId = new SelectList(db.Exercises, "ID", "Name", weeklyExercise.ExerciseId);
            return View(weeklyExercise);
        }

        // GET: WeeklyExercises/Delete/5
        public ActionResult Delete(int id)
        {
            var weeklyExercise = db.WeeklyExercises.Find(id);

            if (weeklyExercise == null)
            {
                return HttpNotFound();
            }

            return View(weeklyExercise);
        }

        // POST: WeeklyExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var weeklyExercise = db.WeeklyExercises.Find(id);

            if (weeklyExercise != null)
            {

                db.WeeklyExercises.Remove(weeklyExercise);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "WorkoutPlans", new {id = weeklyExercise.WorkoutPlanID});
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
