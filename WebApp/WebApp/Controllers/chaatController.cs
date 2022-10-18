using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ChaatsModel;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class ChaatController : Controller
    {
        public static List<Chaat> chaats = new List<Chaat>();
        public IActionResult ChaatDetails()
        {
            ViewBag.UserName = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                chaats = db.Chaats.ToList();

            }
            return View(chaats);
        }

        [HttpGet]
        public IActionResult AddChaat()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddChaat(Chaat c)
        {
            using (var db = new chaatsContext())
            {
                db.Chaats.Add(c);
                db.SaveChanges();
            }
            return RedirectToAction("ChaatDetails");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Chaat c = new Chaat();
            using (var db = new chaatsContext())
            {
                c = db.Chaats.Find(Id);

            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete(Chaat c)
        {
            using (var db = new chaatsContext())
            {
                db.Remove(c);
                db.SaveChanges();

            }
            return RedirectToAction("ChaatDetails");

        }
       public IActionResult Login()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                chaats = db.Chaats.ToList();

            }
            return View();
        }
        

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Chaat c = new Chaat();
            using (var db = new chaatsContext())
            {
                c = db.Chaats.Find(Id);
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Chaat c)
        {
            using (var db = new chaatsContext())
            {
                db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("ChaatDetails");

        }
    }
}
