using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Specialties
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Basligi qeyd edin")]
        [MaxLength(60, ErrorMessage = "Bashliq 60 herfden cox ola bilmez")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Movzu qeyd edin")]
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}