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
            List<Customer> customers = context.Customers.Include("Reservations").ToList();
            return View(customers);
        }

        public JsonResult GetList(string name)
        {
           var customers = context.Customers.Include("Reservations").Where(c => c.FullName.Contains(name)).ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
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
            customer.Created = DateTime.Now;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer == null)
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
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            context.Entry(customer).Property(x => x.Created).IsModified = false;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            context.Customers.Remove(customer);
            context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}