using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaxaHotel.Models
{
    public enum UserType
    {
        admin, restaurant, reception
    }
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İstifadəçinin ad-soyadını yazın.")]
        [MaxLength(30, ErrorMessage = "İstifadəçinin ad-soyadı maximum 30 xarakter olmalıdır.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "İstifadəçi adını yazın.")]
        [MaxLength(50, ErrorMessage = "İstifadəçi adı maximum 50 xarakter olmalıdır.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parolu yazın.")]
        [MaxLength(100, ErrorMessage = "Parol maximum 100 xarakter olmalıdır.")]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Token { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Hesabın hansı kateqoriyaya aid olduğunu yazın.")]
        public bool Status { get; set; }
        public bool? IsDelete { get; set; }
        public UserType Type { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}