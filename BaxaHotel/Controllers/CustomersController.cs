using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaxaHotel.Models;
using BaxaHotel.Data;
using BaxaHotel.Helper;
using System.IO;

namespace BaxaHotel.Controllers
{   [Auth]
    public class CustomersController : Controller
    {
        private BaxaHotelContext context;
        public CustomersController()
        {
            context = new BaxaHotelContext();
        }
        public ActionResult Index()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;
            List<Customer> customers = context.Customers.Include("Reservations").Where(c=>c.IsDelete==false).OrderBy(c=>c.FullName).ToList();
            return View(customers);

        }

        public JsonResult GetList(string name)
        {
            var customers = context.Customers.Include("Reservations").Where(c => c.FullName.Contains(name)&&c.IsDelete==false).OrderBy(c=>c.FullName).ToList();
            return Json(customers.Select(c => new { c.Id, c.FullName, c.PhoneNumber, Date = c.Created.ToString("dd MMM yyyy"), c.IsDelete, c.Status, c.Reservations.Count }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            if(!long.TryParse(customer.SVnum, out long n))
            {
                ModelState.AddModelError("SVnum", "Şəxsiyyət vəsiqəsinin nömrəsinin düzgün yazın, məsələn: 12345678");
                return View(customer);
            }

            //if (customer.File.ContentType != "image/png" || customer.File.ContentType != "image/jpeg")
            //{
            //    ModelState.AddModelError("File", "Png və ya jpeg formatında şəkil seçin.");
            //    return View(customer);
            //}
            //if (customer.File.ContentLength/1024/1024>2)
            //{
            //    ModelState.AddModelError("File", "Şəkilin həcmi 2 MB-dan böyük olmamalıdır");
            //    return View(customer);
            //}
            //var text = customer.File.FileName.Split('.');
            //customer.Photo = Guid.NewGuid().ToString()+text[text.Length-1];
            //var path = Path.Combine(Server.MapPath("Uploads"), customer.Photo);
            ////customer.File.SaveAs();
            customer.IsDelete = false;
            customer.Created = DateTime.Now;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

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
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            if (!long.TryParse(customer.SVnum, out long n))
            {
                ModelState.AddModelError("SVnum", "Şəxsiyyət vəsiqəsinin nömrəsinin düzgün yazın, məsələn: 12345678");
                return View(customer);
            }
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            Customer cusm = context.Customers.FirstOrDefault(r => r.PhoneNumber == customer.PhoneNumber);
            if (cusm!=null && cusm.Id!=customer.Id)
            {
                ModelState.AddModelError("PhoneNumber", customer.PhoneNumber+ " telefon nömrəsi artıq qeydiyyatdan keçib.");
                return View(customer);
            }

            context.Entry(customer).Property(x => x.Created).IsModified = false;
            context.Entry(customer).Property(x => x.IsDelete).IsModified = false;
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

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
            string token = Request.Cookies["token"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.Token == token);
            ViewBag.User = user;

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