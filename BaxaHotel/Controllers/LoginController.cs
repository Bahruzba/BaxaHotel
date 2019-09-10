using BaxaHotel.Data;
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
    public class LoginController : Controller
    {
        private BaxaHotelContext context;
        public LoginController()
        {
            context = new BaxaHotelContext();
        }
        // GET: Login
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
            if (user == null || Crypto.VerifyHashedPassword(user.Password, login.Password))
            {
                ModelState.AddModelError("Password", "Login ve ya parol yanlışdır.");
                return View();
            }
            Response.Cookies["Token"].Value = Guid.NewGuid().ToString();
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