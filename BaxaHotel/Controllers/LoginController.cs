using BaxaHotel.Data;
using BaxaHotel.Helper;
using BaxaHotel.Models;
using BaxaHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginAction login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            User user = context.Users.FirstOrDefault(u => u.UserName == login.UserName);
            if (user == null || !Crypto.VerifyHashedPassword(user.Password, login.Password))
            {
                ModelState.AddModelError("Password", "Login ve ya parol yanlışdır.");
                return View();
            }
            user.Token = Guid.NewGuid().ToString();
            context.SaveChanges();
            Response.Cookies["Token"].Value = user.Token;
            Response.Cookies["Token"].Expires = DateTime.Now.AddDays(1);
            return RedirectToAction("index", "customers");
        }

        public ActionResult logout()
        {
            if (Request.Cookies["Token"] != null)
            {
                Response.Cookies["Token"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("index", "login");
        }
    }
}