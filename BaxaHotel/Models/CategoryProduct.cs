using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kateqoriyanın adını yazın.")]
        [MaxLength(20, ErrorMessage = "Kateqoriyanın adı maximum 20 xarakter olmalıdır.")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}