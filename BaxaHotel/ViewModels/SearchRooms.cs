using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.ViewModels
{
    public class SearchRooms
    {
        //[Required(ErrorMessage = "Sifariş tarixini yazın")]
        [DisplayName("Başlanma tarixi")]
        public DateTime? Start { get; set; }
        //[Required(ErrorMessage = "Sifariş tarixini yazın")]
        [DisplayName("Bitmə tarixi")]
        public DateTime? End { get; set; }
        //[Required(ErrorMessage = "Otağın qiymətini yazın.")]
        //[Range(100, 1000, ErrorMessage = "Otağın gecəsi 10-300 AZN arası olamalıdır.")]
        [DisplayName("Minimum məbləğ")]
        public double? MinPrice { get; set; }
        //[Required(ErrorMessage = "Otağın qiymətini yazın.")]
        [DisplayName("Maximum məbləğ")]
        //[Range(100, 1000, ErrorMessage = "Otağın gecəsi 10-300 AZN arası olamalıdır.")]
        public double? MaxPrice { get; set; }
        //[Required(ErrorMessage = "Otağın böyüklər üçün tutumunu yazın.")]
        [DisplayName("Tək nəfərlik yataq")]
        //[Range(1, 5, ErrorMessage = "5-dən artıq böyüklər üçün tək nəfərlik çarpayısı olan otaq yoxdur.")]
        public int? SinglePersonBedroom { get; set; }
        //[Range(1, 3, ErrorMessage = "3-dən artıq böyüklər üçün çüt nəfərlik çarpayısı olan otaq yoxdur.")]
        [DisplayName("2 nəfərlik yataq")]
        public int? PairPersonBedroom { get; set; }
        //[Required(ErrorMessage = "Otağın uşaqlar üçün tutumunu yazın.")]
        [DisplayName("Uşaq yatağı")]
        //[Range(1, 5, ErrorMessage = "5-dən artıq uşaq çarpayısı olan otaq yoxdur.")]
        public int? ChildBedroom { get; set; }
    }
}