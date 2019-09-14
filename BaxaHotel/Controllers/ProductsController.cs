using BaxaHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private BaxaHotelContext contex;
        public ProductsController()
        {
            contex = new BaxaHotelContext();
        }
        public ActionResult Index()
        {


            return View();
        }
    }
}