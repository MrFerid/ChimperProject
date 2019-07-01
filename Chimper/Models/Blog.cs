using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Blog
    {
        public int id { get; set; }
        [Display( Name ="Userin adi")]
        [Required(ErrorMessage = "Ad bolmesini doldurun")]
        [MaxLength(60)]
        public string UserName { get; set; }
        [Display(Name = "Userin soyadi")]
        [Required(ErrorMessage = "Soyad bolmesini doldurun")]
        [MaxLength(60)]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Basligi qeyd edin")]
        [MaxLength(60, ErrorMessage = "Bashliq 60 herfden cox ola bilmez")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Bir text yazin")]
        public string Text { get; set; }
        public string Photo { get; set; }
        public DateTime ShareDate { get; set; }
    }
}