using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ümumi məbləği yazın.")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Rezervasiya başlama tarixini yazın.")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Rezervasiya bitəcəyi tarixi yazın.")]
        public DateTime End { get; set; }
        public DateTime? Closed { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Otaq nömrəsini yazın.")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required(ErrorMessage = "Müştəri nömrəsini yazın.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}