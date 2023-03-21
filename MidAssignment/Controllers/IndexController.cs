using MidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class IndexController : Controller
    {
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult Reg()
            {

                var db = new ZHEntities();
                var users = db.Users.ToList();
                return View(users);
            }
            [HttpGet]
            public ActionResult HomePage()
            {
                return View();
            }
            [HttpGet]
            public ActionResult Registration()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Registration(User user)
            {
                var db = new ZHEntities();
                db.Users.Add(user);
                db.SaveChanges();
                TempData["msg"] = "Sucessfully Added";
                return RedirectToAction("Reg");
            }

            [HttpGet]
            public ActionResult AdminDashboard()
            {
                var db = new ZHEntities();
                var orders = db.Orders.ToList();
                return View(orders);
            }

            [HttpGet]
            public ActionResult EmployeeAdmin()
            {
                var db = new ZHEntities();
                var users = db.Users.ToList();
                return View(users);
            }
            [HttpGet]
            public ActionResult Order()
            {

                var db = new ZHEntities();
                var orders = db.Orders.ToList();
                TempData["msg"] = "Successfully Added";
                return View(orders);
            }

            [HttpGet]
            public ActionResult RestaurantAdmin()
            {
                var db = new ZHEntities();
                var users = db.Users.ToList();
                return View(users);
            }


            [HttpGet]
            public ActionResult RestaurantDashboard()
            {
                return View();
            }

        [HttpGet]
        public ActionResult RestaurantEdit()
        {
            var db = new ZHEntities();
            var users = db.Users.ToList();
            return View(users);

        }

        [HttpGet]
            public ActionResult RestaurantDetails()
            {
                var db = new ZHEntities();
                var users = db.Users.ToList();
                return View(users);
            }

            public ActionResult EmployeeDashboard()
            {
                return View();
            }
            [HttpPost]
            public ActionResult RestaurantDashboard(Order order)
            {
                var db = new ZHEntities();
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Order");
            }

            [HttpGet]
            public ActionResult AdminHistory()
            {
                var db = new ZHEntities();
                var orders = db.Orders.ToList();
                return View(orders);
            }
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(User user)
            {
                TempData["msg"] = "Logged in successfully.";

                if (ModelState.IsValid)
                {
                    using (var db = new ZHEntities())
                    {
                        var obj = db.Users.Where(a => a.email.Equals(user.email) && a.password.Equals(user.password)).FirstOrDefault();
                        if (obj != null)
                        {

                            if (obj.type == "Admin")
                            {
                                return RedirectToAction("AdminDashBoard");
                            }
                            else if (obj.type == "Restaurant")
                            {
                                return RedirectToAction("RestaurantDashBoard");
                            }
                            else
                            {
                                return RedirectToAction("EmployeeDashBoard");
                            }

                        }
                    }
                }
                return View(user);
            }
        }
    }