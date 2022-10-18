using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ChaatsModel;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        public static List<Chaat> chaats = new List<Chaat>();
        public static List<Drink> drinks = new List<Drink>();
        public IActionResult UserChaatDetails()
        {
            ViewBag.UserName = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                chaats = db.Chaats.ToList();

            }
            return View(chaats);
        }

        public IActionResult UserDrinkDetails()
        {
            ViewBag.UserName = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
                drinks = db.Drinks.ToList();

            }
            return View(drinks);
        }

        public IActionResult User()
        {
            return View();

        }
        
        public IActionResult Buy()
        {
            return View();
           
        }
        public IActionResult TY()
        {
            return View();

        }

    }
}
