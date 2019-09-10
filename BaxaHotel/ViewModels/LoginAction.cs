using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.ViewModels
{
    public class LoginAction
    {
        [Required(ErrorMessage ="Istifadəçi adını yazın.")]
        [MaxLength(50, ErrorMessage = "İstifadəçi adı maximum 50 xarakter ola bilər.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parolu yazın.")]
        [MaxLength(20, ErrorMessage = "Parol maximum 20 xarakter ola bilər.")]
        public string Password { get; set; }
    }
}