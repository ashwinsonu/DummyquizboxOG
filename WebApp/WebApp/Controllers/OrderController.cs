using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ChaatsModel;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        public static List<Order> orders= new List<Order>();
        public IActionResult OrderDetails()
        {
            ViewBag.UserName = HttpContext.Session.GetString("Username");
            using (var db = new chaatsContext())
            {
               orders = db. Orders.ToList();

            }
            return View(orders);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddOrder(Order o)
        {
            using (var db = new chaatsContext())
            {
                db.Orders.Add(o);
                db.SaveChanges();
            }
            return RedirectToAction("OrderDetails");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Order o = new Order();
            using (var db = new chaatsContext())
            {
                o = db.Orders.Find(Id);

            }
            return View(o);
        }
        [HttpPost]
        public IActionResult Delete(Order  o)
        {
            using (var db = new chaatsContext())
            {
                db.Remove(o);
                db.SaveChanges();

            }
            return RedirectToAction("OrderDetails");

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
            Order o = new Order();
            using (var db = new chaatsContext())
            {
                o = db.Orders.Find(Id);
            }
            return View(o);
        }
        [HttpPost]
        public IActionResult Edit(Order o)
        {
            using (var db = new chaatsContext())
            {
                db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("OrderDetails");

        }
    }
}
