using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Message
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ad bolmesini doldurun")]
        [MaxLength(60, ErrorMessage = "Ad 60 herfden cox ola bilmez")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad bolmesini doldurun")]
        [MaxLength(60, ErrorMessage = "Soyad 60 herfden cox ola bilmez")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email bolmesini doldurun")]
        [EmailAddress(ErrorMessage = "Email adresi duzgun deyil")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Movzu bolmesini doldurun")]
        [MaxLength(100, ErrorMessage = "Movzu bashligi 100 herfden cox ola bilmez")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Mesaj bolmesini doldurun")]
        [MinLength(20,ErrorMessage = "Mesaj 20 herfden az ola bilmez")]
        public string Text { get; set; }
    }
}