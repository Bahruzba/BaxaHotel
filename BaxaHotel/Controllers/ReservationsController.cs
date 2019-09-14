using BaxaHotel.Data;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class ReservationsController : Controller
    {
        // GET: Reservation
        private BaxaHotelContext context;
        public ReservationsController()
        {
            context = new BaxaHotelContext();
        }
        public ActionResult Index()
        {
            List<Reservations> reservations = context.Reservations.Include("Customer").Include("User").Include("Room").Where(r => r.Closed == null).OrderBy(r=>r.End).ToList();
            return View(reservations);
        }

        public ActionResult Getlist(string name)
        {
            List<Reservations> reservations = context.Reservations.Include("Customer").Include("User").Include("Room").Where(r=>r.)

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}