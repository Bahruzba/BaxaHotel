using BaxaHotel.Data;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected BaxaHotelContext context;
        public BaseController()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u=>u.Token== token);
            context = new BaxaHotelContext();
            ViewBag.User = user;

        }
    }
}