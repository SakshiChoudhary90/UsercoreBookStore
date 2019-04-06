using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class BookCategoryController : Controller
    {
        Book_Store_DbContext context = new Book_Store_DbContext();
        public IActionResult Index()
        {
            var bc = context.BookCategories.ToList();
            return View(bc);
        }

        public IActionResult CategoryDisplay(int id)
        {
            var bk = context.Books.Where(x => x.BookCategoryId == id).ToList();
            return View(bk);
        }
    }
}