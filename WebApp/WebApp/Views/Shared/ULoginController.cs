using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ChaatsModel;

namespace WebApp.Controllers
{
    public class ULoginController : Controller
    {
        private readonly ISession Usession;
        public ULoginController(IHttpContextAccessor httpContextAccessor)
        {
            Usession = httpContextAccessor.HttpContext.Session;

        }

        [HttpGet]
        public IActionResult ULogin()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(UserLogin l)
        {
            using (var db = new chaatsContext())
            {
                UserLogin result = (from i in db.UserLogins
                                   where i.Username == l.Username && i.Password == l.Password
                                   select i).FirstOrDefault();
                if (result != null)
                {
                    HttpContext.Session.SetString("Username", l.Username);
                    return RedirectToAction("User", "User");
                }
                else
                {
                    return View();

                }

            }
        }
        [HttpPost]
        public IActionResult ULogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("ULogin");

        }
        [HttpGet]
        public IActionResult UCreate()
        {
            return View();

        }

        [HttpPost]
        public IActionResult UCreate(UserLogin user)
        {
            using (var db = new chaatsContext())
            {
                db.UserLogins.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("ULogin");

        }


    }
}
