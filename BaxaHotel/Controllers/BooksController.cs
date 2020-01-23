using BaxaHotel.Data;
using BaxaHotel.Models;
using BaxaHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    public class BooksController : BaseController
    {
        //Searc Rooms for Reservations
        public ActionResult Index(SearchRooms searchRooms = null)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }

            if (searchRooms.Start == null)
            {
                searchRooms.Start = DateTime.Now;
            }
            if (searchRooms.End == null)
            {
                searchRooms.End = DateTime.Now.AddDays(1);
            }

            List<Room> rooms = context.Rooms.Include("Reservations").Where(r => r.IsDelete == false && r.Status == true &&
            (searchRooms.MinPrice != null ? r.Price >= searchRooms.MinPrice : true) &&
            (searchRooms.MaxPrice != null ? r.Price <= searchRooms.MaxPrice : true) &&
            (searchRooms.PairPersonBedroom != null ? r.PairPersonBedroom == searchRooms.PairPersonBedroom : true) &&
            (searchRooms.SinglePersonBedroom != null ? r.SinglePersonBedroom == searchRooms.SinglePersonBedroom : true) &&
            (searchRooms.ChildBedroom != null ? r.ChildBedroom == searchRooms.ChildBedroom : true)).ToList();
            List<Room> rooms1 = new List<Room>();
            rooms1.AddRange(rooms);
            foreach (var room in rooms)
            {
                foreach (var reservation in room.Reservations)
                {
                    if (reservation.Start < searchRooms.Start && reservation.End > searchRooms.Start || searchRooms.End > reservation.Start && searchRooms.Start < reservation.Start)
                    {
                        rooms1.Remove(room);
                        break;
                    }
                }
            }
            SearchRoomsToBook searchRoomsToBook = new SearchRoomsToBook
            {
                SearchRooms=searchRooms,
                Rooms= rooms
            };
            if (searchRooms.Start >= searchRooms.End)
            {
                ModelState.AddModelError("Start","Tarixləri düz yazın");
                return View(searchRooms);
            }

            return View(searchRoomsToBook);
        }
        
        //Searc Rooms for Reservations
        public ActionResult SelectCustomer(DateTime start, DateTime end, int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }
            ViewBag.User = user;


            ViewBag.PriceRoom =(end - start).TotalDays*context.Rooms.Find(id).Price;
            SearcCustomerToBook searcCustomerToBook = new SearcCustomerToBook
            {
                Customers = context.Customers.ToList(),
                Start = start,
                End = end,
                Id = id
            };
            return View(searcCustomerToBook);
        }
        
        //SelectCustomer for reservation
        public ActionResult CompleteReservation(int id, int cid, DateTime start, DateTime end )
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }
            ViewBag.User = user;

            Reservations reservation = new Reservations
            {
                TotalPrice= (end - start).TotalDays * context.Rooms.Find(id).Price,
                Start = start,
                End = end,
                Created = DateTime.Now,
                RoomId =id,
                CustomerId=cid,
                UserId= user.Id
            };
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return RedirectToAction("index", "reservations");
        }

        //finis reservations
        public ActionResult FinishReservation(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            if (user.Type == UserType.restaurant)
            {
                return RedirectToAction("index", "login");
            }
            ViewBag.User = user;

            Reservations reservation = context.Reservations.Find(id);
            if (reservation == null||reservation.Closed != null)
            {
                return new HttpNotFoundResult();
            }

            reservation.Closed = DateTime.Now;
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}