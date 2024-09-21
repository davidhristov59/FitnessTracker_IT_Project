using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using NOVA_VERZIJA_IT.Models;

namespace NOVA_VERZIJA_IT.Controllers
{
    public class DietAndNutritionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietAndNutrition
        public ActionResult Index()
        {
            var model = new DietAndNutrition
            {
                BreakfastFoods = db.Foods.Where(f => f.MealType == "Breakfast").ToList(),
                LunchFoods = db.Foods.Where(f => f.MealType == "Lunch").ToList(),
                DinnerFoods = db.Foods.Where(f => f.MealType == "Dinner").ToList(),
                SnackFoods = db.Foods.Where(f => f.MealType == "Snack").ToList(),
            };

            return View(model);

            //return View(db.DietAndNutrition.ToList());
        }
        
        public ActionResult AddFood()
        {
            var model = new FoodItemViewModel();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFood(FoodItemViewModel model)
        {
            if (ModelState.IsValid)
            {

                var fooditem = new Food
                {
                    Name = model.Name,
                    ServingSize = model.ServingSize,
                    Protein = model.Protein,
                    Carbs = model.Carbs,
                    Fats = model.Fats,
                    Calories = model.Calories,
                    MealType = model.MealType,
                    ImageUrl = model.ImageUrl,
                    Ingredients = model.Ingredients,
                   
                };

                db.Foods.Add(fooditem);
                Debug.WriteLine(db.Entry(fooditem).State); // Should be 'Added'

                db.SaveChanges();

                return RedirectToAction("Index", "DietAndNutrition");

            }

            return View(model);
        }


        public ActionResult EditFood(int id)
        {
            var food = db.Foods.Find(id);

            if(food == null)
            {
                return HttpNotFound();
            }

            return View(food);
        }

        [HttpPost]
        public ActionResult EditFood(Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "DietAndNutrition");
            }

            return View(food);
        }

        public ActionResult DeleteFood(int id)
        {
            var food = db.Foods.Find(id);

            if(food == null)
            {
                return HttpNotFound();
            }

            return View(food);
        }

        [HttpPost, ActionName("DeleteFood")]
        public ActionResult DeleteFoodConfirmed(int id)
        {

            var food = db.Foods.Find(id);

            db.Foods.Remove(food);
            db.SaveChanges();
             

            return RedirectToAction("Index", "DietAndNutrition");
        }


        // GET: DietAndNutrition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            /*
           DietAndNutrition dietAndNutrition = db.DietAndNutrition.Find(id);

            if (dietAndNutrition == null)
            {
                return HttpNotFound();
            }
            return View(dietAndNutrition);
            */

            var foodItem = db.Foods.Find(id);

            if ( foodItem == null)
            {
                return HttpNotFound();
            }

            return View(foodItem);

        }

        // GET: DietAndNutrition/Create
        public ActionResult Create()
        {
            return View();
        }

        
      
        // POST: DietAndNutrition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaloriesGoal,totalCalories,caloriesRemaining")] DietAndNutrition dietAndNutrition)
        {
            
            if (ModelState.IsValid)
            {
                db.DietAndNutrition.Add(dietAndNutrition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dietAndNutrition);
        }
        

        // GET: DietAndNutrition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietAndNutrition dietAndNutrition = db.DietAndNutrition.Find(id);
            if (dietAndNutrition == null)
            {
                return HttpNotFound();
            }
            return View(dietAndNutrition);
        }

        // POST: DietAndNutrition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaloriesGoal,totalCalories,caloriesRemaining")] DietAndNutrition dietAndNutrition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dietAndNutrition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dietAndNutrition);
        }

        // GET: DietAndNutrition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietAndNutrition dietAndNutrition = db.DietAndNutrition.Find(id);
            if (dietAndNutrition == null)
            {
                return HttpNotFound();
            }
            return View(dietAndNutrition);
        }

        // POST: DietAndNutrition/Delete/5
        /*
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietAndNutrition dietAndNutrition = db.DietAndNutrition.Find(id);
            db.DietAndNutrition.Remove(dietAndNutrition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */


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
