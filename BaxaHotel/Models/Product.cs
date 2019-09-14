using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Məhsulun adını yazın.")]
        [MaxLength(20, ErrorMessage = "Məhsulun adı maximum 20 xarakter olmalıdır.")]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Məhsulun qiymətini yazın.")]
        [Range(0, 300, ErrorMessage = "Məhsulun qiymətini maximum 300 manat olmalıdır.")]
        [DisplayName("Qiyməti")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Məhsulun sayını yazın.")]
        [Range(0, 100, ErrorMessage = "Eyni məhsuldan maximum 100 ədəd olmalıdır.")]
        [DisplayName("Sayı")]
        public int Count { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Məhsulun kateqoriyasını yazın.")]
        [DisplayName("Adı")]
        public CategoryProduct CategoryProduct { get; set; }
        public int CategryProductId { get; set; }
    }
}