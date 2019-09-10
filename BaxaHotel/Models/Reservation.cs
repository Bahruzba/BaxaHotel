using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Rezervasiya başlama tarixini yazın.")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Rezervasiya bitəcəyi tarixi yazın.")]
        public DateTime End { get; set; }
        public DateTime Closed { get; set; }
        public DateTime? Create { get; set; }
        [Required(ErrorMessage = "Otaq nömrəsini yazın.")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required(ErrorMessage = "Müştəri nömrəsini yazın.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}