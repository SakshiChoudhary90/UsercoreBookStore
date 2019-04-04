using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Helper;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class HomeController : Controller
    {
        Book_Store_DbContext context = new Book_Store_DbContext();
        public IActionResult Index()
        {
            var books = context.Books.ToList();
            int i = 0;
            int j = 0;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    i++;
                }
                if (i != 0)
                {
                    foreach (var item in cart)
                    {
                        j++;
                    }
                }
                HttpContext.Session.SetString("CartItem", i.ToString());
            }
            return View(books);

        }
        
    }
}