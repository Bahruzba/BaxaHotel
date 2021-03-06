﻿using BaxaHotel.Data;
using BaxaHotel.Helper;
using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaxaHotel.Controllers
{
    [Auth]
    public class ReservationsController : BaseController
    {
        //list Reservation
        public ActionResult Index()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            List<Reservations> reservations = context.Reservations.Include("Customer").Include("User").Include("Room").OrderBy(r=>r.End).ToList();

            return View(reservations);
        }

        //search Reservation
        public ActionResult Getlist(string name)
        {
            if (name == null || name == "")
            {
                return new HttpNotFoundResult();
            }
            var reservations = context.Reservations.Include("Customer").Include("User").Include("Room").Where(r => r.Customer.FullName.Contains(name) || r.Room.Number.ToString().Contains(name)).ToList();

            return Json(reservations.Select(r => new {r.Id, sta= r.Start.ToUniversalTime(), customer =r.Customer.FullName, room=r.Room.Number, creat = r.Created.ToString("dd MMM yyyy"),closed = r.Closed!=null? r.Closed.Value.ToString("dd MMM yyyy"):null, end = r.End.ToString("dd MMM yyyy"), start = r.Start.ToString("dd MMM yyyy")}), JsonRequestBehavior.AllowGet);
        }

        //activ-passiv Reservation
        public ActionResult Activate(int id)
        {
            Reservations reservation = context.Reservations.FirstOrDefault(r => r.Id == id && r.Closed == null);
            if (reservation == null)
            {
                return new HttpNotFoundResult();
            }
            reservation.Closed = DateTime.Now;
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}