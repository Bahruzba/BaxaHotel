using BaxaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaxaHotel.ViewModels
{
    public class SearchRoomsToBook
    {
        public SearchRooms SearchRooms { get; set; }
        public List<Room>Rooms { get; set; }
    }
}