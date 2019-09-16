using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BaxaHotel.Data;
using BaxaHotel.Models;

namespace BaxaHotel.Controllers
{
    public class DataController : BaseController
    {
        // GET: databasedoldur        
        public ActionResult Index()
        {

            User usr = new User
            {
                FullName = "Yolçu Nasib",
                UserName = "yolchu@code.edu.az",
                Password = Crypto.HashPassword("Bahruza100bal"),
                Created = DateTime.Now,
                Type = UserType.admin
            };
            context.Users.Add(usr);
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                User user = new User
                {
                    FullName = "Ad soyad",
                    UserName = "ad.soyad@mail.ru",
                    Password = Crypto.HashPassword("Bahruza100bal"),
                    Created = DateTime.Now
                };
                if (i%3 == 2)
                {
                    user.Type = UserType.reception;
                }
                else if (i % 3 == 1)
                {
                    user.Type = UserType.restaurant;
                }
                context.Users.Add(user);
                context.SaveChanges();

                Room room = new Room
                {
                    Number = i+1,
                    Price = 25*(i+1),
                    Status = true,
                    PairPersonBedroom = 2,
                    SinglePersonBedroom = 3,
                    ChildBedroom = 3,
                    IsDelete = false,
                    Created=DateTime.Now,
                    Photo = i+".jpeg"
                };
                context.Rooms.Add(room);
                context.SaveChanges();

                Customer customer = new Customer
                {
                    FullName = "Ad Soyad"+(i+1),
                    PhoneNumber="55696557" +i,
                    SVnum="1234567" +i,
                    Created= DateTime.Now,
                    Status= true,
                    IsDelete=false,
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                Reservations reservations = new Reservations
                {
                    TotalPrice= 150,
                    Start=DateTime.Now,
                    End=DateTime.Now.AddDays(6),
                    Created= DateTime.Now,
                    RoomId=room.Id,
                    CustomerId=customer.Id,
                    UserId=user.Id
                };
                context.Reservations.Add(reservations);
                context.SaveChanges();
            }
            return RedirectToAction("index","login");
        }
    }
}