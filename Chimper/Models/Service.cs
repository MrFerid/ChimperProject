using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Service
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Basligi qeyd edin")]
        [MaxLength(60,ErrorMessage = "Bashliq 60 herfden cox ola bilmez")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Bir text yazin")]
        public string Text { get; set; }
        public string icon { get; set; }
        public bool Type { get; set; }
    }
}