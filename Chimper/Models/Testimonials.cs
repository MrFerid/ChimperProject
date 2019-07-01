using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Testimonials
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ad qeyd edin")]
        [MaxLength(60, ErrorMessage = "Ad 60 herfden cox ola bilmez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad qeyd edin")]
        [MaxLength(60, ErrorMessage = "Soyad 60 herfden cox ola bilmez")]
        public string Surname { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Texti qeyd edin")]
        public string Text { get; set; }
    }
}