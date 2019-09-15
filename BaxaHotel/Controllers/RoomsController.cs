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
        // list Rooms
        public ActionResult Index()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            List<Room> rooms = context.Rooms.Include("Reservations").Where(r=>r.IsDelete==false).OrderBy(r=>r.Number).ToList();
            return View(rooms);
        }

        // search room
        public JsonResult GetList(string name)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            var rooms = context.Rooms.Where(r => r.Number.ToString().Contains(name)&&r.IsDelete == false).OrderBy(r=>r.Number).ToList();
            return Json(rooms.Select(r => new { r.Id, r.Number, r.Price, r.PairPersonBedroom, r.SinglePersonBedroom, r.ChildBedroom, r.Status,r.IsDelete, Date = r.Created.ToString("dd MMM yyyy") }), JsonRequestBehavior.AllowGet);
        }

        //view create room
        [HttpGet]

        //view create room
        public ActionResult Create()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

            return View();
        }

        //update room
        [HttpPost]
        public ActionResult Create(Room room)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

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

        //view update room
        [HttpGet]
        public ActionResult Update(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

            Room room = context.Rooms.Find(id);
            if (room == null||room.IsDelete==true)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //update room
        [HttpPost]
        public ActionResult Update(Room room)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

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

        //delete room
        public ActionResult Delete(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

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

        //active-passive room
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