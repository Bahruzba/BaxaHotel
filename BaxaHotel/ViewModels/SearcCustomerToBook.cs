using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaxaHotel.ViewModels
{
    public class SearcCustomerToBook
    {
        public List<Customer> Customers { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Id { get; set; }
        public int Cid { get; set; }
    }
}