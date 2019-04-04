using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    public class AuthorController : Controller
    {
        BookStoreDbContext context = new BookStoreDbContext();
        public ViewResult Index()
        {
            var auth = context.Authors.ToList();
            return View(auth);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author a1)
        {

            context.Authors.Add(a1);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Author Authr = context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            context.SaveChanges();
            return View(Authr);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Author auth = context.Authors.Find(id);
            return View(auth);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author d1)
        {
            var auth = context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();
            context.Authors.Remove(auth);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Author Authr = context.Authors.Where(x => x.AuthorId == id).SingleOrDefault();


            return View(Authr);
        }
        [HttpPost]
        public ActionResult Edit(Author a1)
        {
            Author Authr = context.Authors.Where
                (x => x.AuthorId == a1.AuthorId).SingleOrDefault();
            context.Entry(Authr).CurrentValues.SetValues(a1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}