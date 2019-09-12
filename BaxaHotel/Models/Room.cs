using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public enum BedType
    {
        Tək, Cüt
    }

    public class Room
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Otaq nömrəsini yazın.")]
        [Range(1, 1000, ErrorMessage ="Otaq nömrəsi 1000-dən yuxarı ola bilməz")]
        public int Number { get; set; }
        [Required(ErrorMessage ="Otağın qiymətini yazın.")]
        [Range(100, 1000, ErrorMessage = "Otağın bir gecəsi 1000 manatdan-dən yuxarı ola bilməz")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Otağın statusu qeyd olunmayıb.")]
        public bool Status { get; set; }
        [Required(ErrorMessage ="Otağın böyüklər üçün tutumunu yazın.")]
        [Range(1, 5, ErrorMessage = "5-dən artıq böyük üçün təkli çarpayısı olan otaq yoxdur.")]
        public int? SinglePersonBedroom { get; set; }
        public bool? IsDelete { get; set; }
        [Range(1, 3, ErrorMessage = "3-dən artıq böyük üçün çütli çarpayısı olan otaq yoxdur.")]
        public int? PairPersonBedroom { get; set; }
        [Required(ErrorMessage = "Otağın uşaqlar üçün tutumunu yazın.")]
        [Range(1, 5, ErrorMessage = "5-dən artıq uşaq çarpayısı olan otaq yoxdur.")]
        public int? ChildBedroom { get; set; }
        [Required(ErrorMessage ="Otaq haqqında məlumatları yazın.")]
        [MaxLength(300, ErrorMessage ="Otaq haqqında məlumatları yazın.")]
        public string Desc { get; set; }
        public DateTime Created { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}