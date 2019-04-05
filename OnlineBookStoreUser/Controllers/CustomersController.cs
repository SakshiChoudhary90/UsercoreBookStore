using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class CustomersController : Controller
    {
        Book_Store_DbContext context = new Book_Store_DbContext();



        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customers cust)
        {
            context.Customers.Add(cust);
            context.SaveChanges();

            return RedirectToAction("Login", "Customers");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Customers cust)

        {

            var user = context.Customers.Where(x => x.UserName == cust.UserName && x.Password.Equals(cust.Password)).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Invalid Credential";
                return View("Login");
            }
            else
            {
                int custId = user.CustomerId;
                //var obj = context.Customers.Where(a => a.UserName.Equals(cust.UserName) && a.Password.Equals(cust.Password)).FirstOrDefault();
                if (user != null)
                {

                    HttpContext.Session.SetString("uname", cust.UserName);
                    HttpContext.Session.SetString("cID", custId.ToString());
                    //return RedirectToAction("Details", "Customers", new { @id = custId });
                    //return RedirectToAction("CheckOut", "Cart", new { @id = custId });
                    return RedirectToAction("Profile", "Customers", new { @id = custId });
                }
                else
                {
                    ViewBag.Error = "Invalid Credential";
                    return View("Index");
                }

            }
                 

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            Customers cust = context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            //Books bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            context.SaveChanges();
            return View(cust);
        }

        public ActionResult Profile(int id)
        {
            Customers cust = context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();

            return View(cust);
        }

        public ActionResult Order(int id)
        {

            return View();
        }

        public ActionResult SavedAddress()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();

            return View(cust);
        }
        [HttpPost]
        public ActionResult ChangePassword(int id, Customers d1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            cust.Password = d1.Password;
            context.SaveChanges();

            return RedirectToAction("Profile", new { @id = custId });
        }
        [HttpGet]
        public ActionResult Edit()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();

            return View(cust);
        }
        [HttpPost]
        public ActionResult Edit(int id, Customers d1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            context.Entry(cust).CurrentValues.SetValues(d1);
            context.SaveChanges();
            
            return RedirectToAction("Profile", new { @id = custId });
        }

    }
}



