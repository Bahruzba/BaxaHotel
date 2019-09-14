using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BaxaHotel.Models;

namespace BaxaHotel.Data
{
    public class BaxaHotelContext:DbContext
    {
        public BaxaHotelContext() : base("BaxaHotelContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
    }
}