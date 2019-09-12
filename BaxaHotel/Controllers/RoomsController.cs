using BaxaHotel.Data;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
            List<Room> rooms = context.Rooms.Include("Reservations").OrderBy(r=>r.Number).ToList();
            return View(rooms);
        }

        public JsonResult GetList(string name)
        {
            var rooms = context.Rooms.Include("Reservations").Where(r => r.Number.ToString().Contains(name)).OrderBy(r=>r.Number).ToList();
            return Json(rooms, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {

            if (!ModelState.IsValid)
            {
                return View(room);
            }

            if (context.Rooms.Any(r => r.Number == room.Number))
            {
                ModelState.AddModelError("Number", room.Number+" nömrəli otaq mövcuddur.");
                return View(room);
            }
            room.Status = true;
            room.Created = DateTime.Now;
            context.Rooms.Add(room);
            context.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [HttpPost]
        public ActionResult Update(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }


            context.Entry(room).State = System.Data.Entity.EntityState.Modified;
            context.Entry(room).Property(x => x.Created).IsModified = false;

            Room room1 = context.Rooms.FirstOrDefault(r => r.Number == room.Number);

            if (room1 != null && room1.Id != room.Id)
            {
                ModelState.AddModelError("Number", room.Number + " nömrəli otaq mövcuddur.");
                return View(room);
            }

            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Room room = context.Rooms.Include("Reservations").FirstOrDefault(p=>p.Id==id);

            if (room == null)
            {
                return HttpNotFound();
            }
            if (room.Reservations.Count == 0)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("index");
        }

        public ActionResult Activate(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            room.Status = true;
            context.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult Passive(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            room.Status = false;
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}