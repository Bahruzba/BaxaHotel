using BaxaHotel.Data;
using BaxaHotel.Helper;
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
            context = new BaxaHotelContext();

        }
    }
}