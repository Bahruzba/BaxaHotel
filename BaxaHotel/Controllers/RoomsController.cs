using BaxaHotel.Data;
using BaxaHotel.Helper;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    [Auth]
    public class RoomsController : BaseController
    {
        // GET: Rooms
        public ActionResult Index()
        {
            List<Room> rooms = context.Rooms.Include("Reservations").Where(r=>r.IsDelete==false).OrderBy(r=>r.Number).ToList();
            return View(rooms);
        }

        public JsonResult GetList(string name)
        {
            var rooms = context.Rooms.Where(r => r.Number.ToString().Contains(name)&&r.IsDelete == false).OrderBy(r=>r.Number).ToList();
            return Json(rooms.Select(r => new { r.Id, r.Number, r.Price, r.PairPersonBedroom, r.SinglePersonBedroom, r.ChildBedroom, r.Status,r.IsDelete, Date = r.Created.ToString("dd MMM yyyy") }), JsonRequestBehavior.AllowGet);
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
            room.IsDelete = false;
            room.Created = DateTime.Now;
            context.Rooms.Add(room);
            context.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Room room = context.Rooms.Find(id);
            if (room == null||room.IsDelete==true)
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
            context.Entry(room).Property(x => x.IsDelete).IsModified = false;

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
                return new HttpNotFoundResult();
            }
            if (room.Reservations.Count == 0)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            room.IsDelete = true;
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Activate(int id)
        {
            Room room = context.Rooms.FirstOrDefault(r=>r.Id==id&&r.IsDelete==false);;
            if (room == null)
            {
                return new HttpNotFoundResult();
            }
            if (room.Status == true)
            {
                room.Status = false;
            }
            else
            {
                room.Status = true;
            }
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}