using BaxaHotel.Data;
using BaxaHotel.Helper;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    [Auth]
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u=>u.Token==token);
            ViewBag.User = user;
            if (user.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }
            List<User> users = context.Users.Where(u=>u.IsDelete==false).OrderBy(u=>u.Type).ToList();
            return View(users);
        }

        public ActionResult Getlist(string name)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type != UserType.admin)
            {
                return new HttpNotFoundResult();
            }

            var users = context.Users.Where(u=>u.FullName.Contains(name)&& u.IsDelete == false).OrderBy(u=>u.Type).ToList();
            return Json(users.Select(u => new { u.Id, u.FullName, u.UserName, Date = u.Created.ToString("dd MMM yyyy"), u.Type, u.Status, u.IsDelete}), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User usr = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (usr.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            if (user != null)
            {
                user.Created = DateTime.Now;
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (context.Users.Any(r => r.UserName== user.UserName))
            {
                ModelState.AddModelError("UserName", user.UserName + " adlı istifadəçi artıq mövcuddur.");
                return View(user);
            }

            user.IsDelete = false;
            user.Password = Crypto.HashPassword(user.Password);
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            User usr = context.Users.Find(id);
            if (usr == null||usr.IsDelete==true)
            {
                return HttpNotFound();
            }

            return View(usr);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User usr = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (usr.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Password = Crypto.HashPassword(user.Password);
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.Entry(user).Property(x => x.Created).IsModified = false;
            context.Entry(user).Property(x => x.IsDelete).IsModified = false;

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
            string token = Request.Cookies["token"].Value.ToString();
            User usr = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = usr;
            if (usr.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            User user = context.Users.Include("Reservations").FirstOrDefault(u=>u.Id==id);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }
            if (user.Reservations.Count == 0)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            user.IsDelete = true;
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Activate(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User usr = context.Users.FirstOrDefault(u => u.Token == token);
            if (usr.Type != UserType.admin)
            {
                return RedirectToAction("index", "login");
            }

            User user = context.Users.FirstOrDefault(u=>u.Id==id&&u.IsDelete==false);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }
            if (user.Status == true)
            {
                user.Status = false;
            }
            else
            {
                user.Status = true;
            }
            context.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}