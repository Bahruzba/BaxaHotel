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
    public class BooksController : Controller
    {
        // GET: Books
        private BaxaHotelContext context;
        public BooksController()
        {
            context = new BaxaHotelContext();
        }

        public ActionResult Index(SearchRooms searchRooms = null)
        {
            if (searchRooms.Start == null)
            {
                searchRooms.Start = DateTime.Now;
            }
            if (searchRooms.End == null)
            {
                searchRooms.End = DateTime.Now.AddDays(1);
            }

            List<Room> rooms = context.Rooms.Include("Reservations").Where(r => r.IsDelete == false && r.Status == true &&
            searchRooms.MinPrice != null ? r.Price >= searchRooms.MinPrice : true &&
            searchRooms.MaxPrice != null ? r.Price <= searchRooms.MaxPrice : true &&
            searchRooms.PairPersonBedroom != null ? r.PairPersonBedroom == searchRooms.PairPersonBedroom : true &&
            searchRooms.SinglePersonBedroom != null ? r.SinglePersonBedroom == searchRooms.SinglePersonBedroom : true &&
            searchRooms.ChildBedroom != null ? r.ChildBedroom == searchRooms.ChildBedroom : true).ToList();
            List<Room> rooms1 = new List<Room>();
            return Content(rooms.Count.ToString());

            //rooms1.AddRange(rooms);
            //if (rooms1.Count == rooms.Count)
            //{
            //    return Content("sedrfgyhu");
            //}
            //int a = -1;
            foreach (var room in rooms)
            {
                //a++;
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
            return View(searchRoomsToBook);
            return Content(rooms1[0].Id.ToString() + "  " + rooms1[1].Id.ToString() + "  " + rooms1[2].Id.ToString() + "  " );
        }


        //public ActionResult Search(SearchRooms searchRooms=null)
        //{
        //    if (searchRooms.Start == null)
        //    {
        //        ModelState.AddModelError("Start", "Başlanğıc tarixini yazın");
        //    }
        //    if (searchRooms.End == null)
        //    {
        //        ModelState.AddModelError("End", "Bitmə tarixini yazın");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(searchRooms);
        //    }


        //    List<Room> rooms = context.Rooms.Include("Reservations")
        //        .Where(r => r.IsDelete == false && r.Status == true).ToList();
        //    List<Room> rooms1 = new List<Room>();
        //    rooms1.AddRange(rooms);
        //    foreach (var room in rooms)
        //    {
        //        foreach (var reservation in room.Reservations)
        //        {
        //            if (reservation.Start < searchRooms.Start && reservation.End > searchRooms.Start||searchRooms.End>reservation.Start&& searchRooms.Start<reservation.Start)
        //            {
        //                rooms1.Remove(room);
        //                break;
        //            }

        //        }
        //    }

        //    SearchRoomsToBook searchRoomsToBook = new SearchRoomsToBook
        //    {
        //        SearchRooms=searchRooms,
        //        Rooms=rooms1

        //    };

        //    return View(searchRoomsToBook);

        //}
    }
}