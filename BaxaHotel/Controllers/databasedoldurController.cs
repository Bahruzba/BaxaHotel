using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BaxaHotel.Data;
using BaxaHotel.Models;

namespace BaxaHotel.Controllers
{
    public class databasedoldurController : BaseController
    {
        // GET: databasedoldur        
        public ActionResult Index()
        {


            for (int i = 0; i < 10; i++)
            {
                string passwordd = "12345678";
                User user = new User
                {
                    FullName = "Ad soyad",
                    UserName = "ad-soyad@mail.ru",
                    Password = Crypto.HashPassword(passwordd),
                    Created = DateTime.Now
                };
                    if (i % 3 == 0)
                    {
                    user.Type = UserType.admin;
                    } else if (i % 3 == 1)
                    {
                    user.Type = UserType.restaurant;
                    }
                    else { user.Type = UserType.reception; }
                context.Users.Add(user);
                context.SaveChanges();


            }
            return View();
        }
    }
}