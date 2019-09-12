using BaxaHotel.Data;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        private BaxaHotelContext context;
        public UsersController()
        {
            context = new BaxaHotelContext();
        }
        public ActionResult Index()
        {
            List<User> users = context.Users.ToList();

            return View(users);
        }

        public JsonResult Getlist(string name)
        {
            var users = context.Users.Where(u=>u.FullName.Contains(name)).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user != null)
            {
                user.Created = DateTime.Now;
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            user.Password = Crypto.HashPassword(user.Password);
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            user.Password = Crypto.HashPassword(user.Password);
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.Entry(user).Property(x => x.Created).IsModified = false;

            User user1= context.Users.FirstOrDefault(r => r.UserName == user.UserName);

            if (user1 != null && user1.Id != user.Id)
            {
                ModelState.AddModelError("UserName", user.UserName+ " istifadəçi adı artıq mövcuddur.");
                return View(user);
            }


            context.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            context.Users.Remove(user);
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}