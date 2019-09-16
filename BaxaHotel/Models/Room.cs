using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Otaq nömrəsini yazın.")]
        [Range(1, 1000, ErrorMessage ="Otaq nömrəsi 1000-dən yuxarı ola bilməz")]
        [DisplayName("Otaq nömrəsi")]
        public int Number { get; set; }
        [Required(ErrorMessage ="Otağın qiymətini yazın.")]
        [Range(10, 300, ErrorMessage = "Otağın bir gecəsi 10-300 manat olmalıdır.")]
        [DisplayName("Məbləğ")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Otağın statusu qeyd olunmayıb.")]
        public bool Status { get; set; }
        [Required(ErrorMessage ="Otağın böyüklər üçün tutumunu yazın.")]
        [Range(1, 5, ErrorMessage = "5-dən artıq böyüklər üçün tək nəfərlik çarpayısı olan otaq yoxdur.")]
        [DisplayName("Tək nəfərlik yataq sayı")]
        public int? SinglePersonBedroom { get; set; }
        public bool? IsDelete { get; set; }
        [Range(1, 3, ErrorMessage = "3-dən artıq böyüklər üçün 2 nəfərlik çarpayısı olan otaq yoxdur.")]
        [DisplayName("2 nəfərlik yataq sayı")]
        public int? PairPersonBedroom { get; set; }
        [Required(ErrorMessage = "Otağın uşaqlar üçün tutumunu yazın.")]
        [Range(1, 5, ErrorMessage = "5-dən artıq uşaq çarpayısı olan otaq yoxdur.")]
        [DisplayName("Uşaq üçün yataq sayı")]
        public int? ChildBedroom { get; set; }
        public DateTime Created { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public List<Reservations> Reservations { get; set; }
    }
}