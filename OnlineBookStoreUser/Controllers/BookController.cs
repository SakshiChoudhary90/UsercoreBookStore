using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Models;

namespace OnlineBookStoreUser.Controllers
{
    public class BookController : Controller
    {
        Book_Store_DbContext context = new Book_Store_DbContext();

        public IActionResult BookCategoryIndex()
        {
            ViewBag.bookcategoryAuthor = context.Books.Include(c => c.Author).ToList();
            ViewBag.bookcategoryPublication = context.Books.Include(p => p.Publication).ToList();
            ViewBag.bookcategoryBook = context.Books.ToList();
            return View();
        }

        [Route("details")]
        public ActionResult Details(int id)
        {
            Books bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            context.SaveChanges();
            return View(bk);
        }
    }
}