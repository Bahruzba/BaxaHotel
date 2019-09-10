using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaxaHotel.Data;

namespace BaxaHotel.Controllers
{
    public class RoomsController : Controller
    {
        // GET: Rooms
        private BaxaHotelContext context;
        public RoomsController()
        {
            context = new BaxaHotelContext();
        }
        public ActionResult Index()
        {
            List<Room> rooms = context.Rooms.Include("Reservations").ToList();
            return View(rooms);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            room.Status = true;
            if (!ModelState.IsValid)
            {
                return View(room);
            }

            context.Rooms.Add(room);
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}