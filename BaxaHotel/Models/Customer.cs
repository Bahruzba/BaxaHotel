using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Müştərinin ad-soyadını yazın.")]
        [MaxLength(30, ErrorMessage = "Müştərinin ad-soyadı maximum 30 xarakter olmalıdır.")]
        [MinLength(5, ErrorMessage = "Müştərinin ad-soyadı minimum 5 xarakter olmalıdır.")]
        [Display(Name ="Ad, soyad")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Müştərinin telefon nömrəsi yazın.")]
        [MaxLength(9, ErrorMessage = "Telefon nömrəsi 9 rəqəmli olmalıdır.")]
        [MinLength(9, ErrorMessage = "Telefon nömrəsi 9 rəqəmli olmalıdır.")]
        [Display(Name = "Əlaqə nömrəsi")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Şəxsiyət vəsiqəsinin nömrəsini yazın.")]
        [MaxLength(8,ErrorMessage = "Şəxsiyət vəsiqəsinin nömrəsini 8 rəqəmli olmalıdır.")]
        [MinLength(8,ErrorMessage = "Şəxsiyət vəsiqəsinin nömrəsini 8 rəqəmli olmalıdır.")]
        [Display(Name = "Şəxsiyyət vəsiqəsinin nömrəsi")]
        public string SVnum { get; set; }
        public DateTime Created { get; set; }
        public bool Status { get; set; }
        public bool? IsDelete { get; set; }
        [MaxLength(100,ErrorMessage ="Şəklin uzunluğu 100 xakarterden uzun olmamalıdır.")]
        public List<Reservations> Reservations { get; set; }
    }
}