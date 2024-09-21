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
    public class FitnessUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FitnessUsers
        public ActionResult Index()
        {
            return View(db.FitnessUsers.ToList());
        }

        // GET: FitnessUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessUser fitnessUser = db.FitnessUsers.Find(id);
            if (fitnessUser == null)
            {
                return HttpNotFound();
            }
            return View(fitnessUser);
        }

        // GET: FitnessUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Address,contactNumber,image,dateOfBirth,membershipCreated,Height,Weight")] FitnessUser fitnessUser)
        {
            if (ModelState.IsValid)
            {
                db.FitnessUsers.Add(fitnessUser);
                db.SaveChanges();
                return RedirectToAction("ListUsers");
            }

            return View(fitnessUser);
        }

        // GET: FitnessUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessUser fitnessUser = db.FitnessUsers.Find(id);
            if (fitnessUser == null)
            {
                return HttpNotFound();
            }
            return View(fitnessUser);
        }

        // POST: FitnessUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Address,contactNumber,image,dateOfBirth,membershipCreated,Height,Weight")] FitnessUser fitnessUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fitnessUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fitnessUser);
        }

        // GET: FitnessUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessUser fitnessUser = db.FitnessUsers.Find(id);
            if (fitnessUser == null)
            {
                return HttpNotFound();
            }
            return View(fitnessUser);
        }

        // POST: FitnessUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FitnessUser fitnessUser = db.FitnessUsers.Find(id);
            db.FitnessUsers.Remove(fitnessUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult addNewWorkoutPlan(int id)
        {
            var model = new FitnessUserWorkoutsPlans();

            model.FitnessID = id;
            model.FitnessUser = db.FitnessUsers.Find(id);
            model.WorkoutPlans = db.WorkoutPlans.ToList();

            return View(model);

        }

        [HttpPost]

        public ActionResult addNewWorkoutPlan(FitnessUserWorkoutsPlans model)
        {
            var user = db.FitnessUsers.Find(model.FitnessID);
            var workout = db.WorkoutPlans.Find(model.WPID);

            user.WorkoutPlans.Add(workout);
            db.SaveChanges();

            return View("Details", user);
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
