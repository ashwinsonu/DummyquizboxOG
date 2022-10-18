using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.ChaatsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Views.Order
{
    public class LoginController : Controller
    {
        private readonly ISession session;

        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(Logintbl l)
        {
            using (var db = new chaatsContext())
            {
                Logintbl result = (from i in db.Logintbls
                                  where i.Username == l.Username && i.Password == l.Password
                                  select i).FirstOrDefault();
                if (result != null)
                {
                    HttpContext.Session.SetString("Username", l.Username);
                    return RedirectToAction("OrderDetails", "Order");
                }
                else
                {
                    return View();

                }

            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Logintbl user)
        {
            using (var db = new chaatsContext())
            {
                db.Logintbls.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Login");

        }




    }
}
