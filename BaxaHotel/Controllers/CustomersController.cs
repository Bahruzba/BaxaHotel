using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaxaHotel.Models;
using BaxaHotel.Data;

namespace BaxaHotel.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BaxaHotelContext context;
        public CustomersController()
        {
            context = new BaxaHotelContext();
        }
        public ActionResult Index()
        {
            List<Customer> customers = context.Customers.Include("Reservations").Where(c=>c.IsDelete==false).OrderBy(c=>c.FullName).ToList();
            return View(customers);
        }

        public JsonResult GetList(string name)
        {
            var customers = context.Customers.Include("Reservations").Where(c => c.FullName.Contains(name)&&c.IsDelete==false).OrderBy(c=>c.FullName).ToList();
            return Json(customers.Select(c => new { c.Id, c.FullName, c.PhoneNumber, Date = c.Created.ToString("dd MMM yyyy"), c.IsDelete, c.Status, c.Reservations }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }


            customer.IsDelete = false;
            customer.Created = DateTime.Now;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer == null||customer.IsDelete==true)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            if (context.Customers.Any(r => r.PhoneNumber== customer.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", customer.PhoneNumber+ " telefon nömrəsi artıq qeydiyyatdan keçib.");
                return View(customer);
            }

            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            context.Entry(customer).Property(x => x.Created).IsModified = false;
            context.Entry(customer).Property(x => x.IsDelete).IsModified = false;
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Customer customer = context.Customers.Include("Reservations").FirstOrDefault(c=>c.Id==id);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            if (customer.Reservations.Count == 0)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            customer.IsDelete = true;
            context.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Activate(int id)
        {
            Customer customer = context.Customers.FirstOrDefault(c=>c.Id==id&&c.IsDelete==false);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }
            if (customer.Status == true)
            {
                customer.Status = false;
            }
            else
            {
                customer.Status = true;
            }
            context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}