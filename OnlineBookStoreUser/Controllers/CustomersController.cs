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

            return RedirectToAction("Login");
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public ActionResult Login(int id, Customers cust)
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
                ViewBag.custName = cust.UserName;
                //var obj = context.Customers.Where(a => a.UserName.Equals(cust.UserName) && a.Password.Equals(cust.Password)).FirstOrDefault();
                if (user != null)
                {

                    HttpContext.Session.SetString("uname", cust.UserName);
                    HttpContext.Session.SetString("id", user.CustomerId.ToString());
                    HttpContext.Session.SetString("cid", custId.ToString());
                    if (ViewBag.cart != null)
                    {
                       

                        return RedirectToAction("CheckOut", "Cart", new { @id = custId });
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Customers", new { @id = custId });
                    }

                   
                }
                else
                {
                    ViewBag.Error = "Invalid Credential";
                    return View("Index");
                }

            }

            

        }
        public ActionResult Details(int id)
        {
            Customers cust = context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            //Books bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            context.SaveChanges();
            return View(cust);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index", "Home");
        }

        [Route("profile")]
        public ActionResult Profile()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);

        }
        [Route("edit")]
        [HttpGet]
        public ActionResult Edit()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(int id,Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            context.Entry(cust).CurrentValues.SetValues(a1);
            context.SaveChanges();
            return RedirectToAction("Profile",new { @id = custId } );
        }

        [Route("resetpassword")]
        [HttpGet]
        public ActionResult ResetPassword()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
        [Route("resetpassword")]
        [HttpPost]
        public ActionResult ResetPassword(int id, Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            cust.Password = a1.Password;
            context.SaveChanges();
            return RedirectToAction("Profile", new { @id = custId });
        }

        
        [HttpGet]
        public ActionResult ResetAddress()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(cust);
        }
      
        [HttpPost]
        public ActionResult ResetAddress(int id, Customers a1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cid"));
            Customers cust = context.Customers.Where
                (x => x.CustomerId == custId).SingleOrDefault();
            cust.Address = a1.Address;
            context.SaveChanges();
            return RedirectToAction("Profile", new { @id = custId });
        }



        public ActionResult Repository(int id)
        {

            ViewBag.ob = context.OrderBooks.Where(x => x.OrderId == id).ToList();
            return View();
            
        }

    }
}



