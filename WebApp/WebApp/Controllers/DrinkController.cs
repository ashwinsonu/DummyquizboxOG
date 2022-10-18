using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ChaatsModel;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class DrinkController : Controller
    {
        public static List<Drink> drinks = new List<Drink>();
        public IActionResult DrinkDetails()
        {
            ViewBag.UserName = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                drinks = db.Drinks.ToList();

            }
            return View(drinks);
        }

        [HttpGet]
        public IActionResult AddDrink()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddDrink(Drink d)
        {
            using (var db = new chaatsContext())
            {
                db.Drinks.Add(d);
                db.SaveChanges();
            }
            return RedirectToAction("DrinkDetails");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Drink d = new Drink();
            using (var db = new chaatsContext())
            {
                d = db.Drinks.Find(Id);

            }
            return View(d);
        }
        [HttpPost]
        public IActionResult Delete(Drink d)
        {
            using (var db = new chaatsContext())
            {
                db.Remove(d);
                db.SaveChanges();

            }
            return RedirectToAction("DrinkDetails");

        }
        /*
        public IActionResult Login()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                orders = db.Orders.ToList();

            }
            return View();
        }

        */
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Drink d = new Drink();
            using (var db = new chaatsContext())
            {
                d = db.Drinks.Find(Id);
            }
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Drink d)
        {
            using (var db = new chaatsContext())
            {
                db.Entry(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("DrinkDetails");

        }
    }
}




