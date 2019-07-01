using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Team
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ad bolmesini doldurun")]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad bolmesini doldurun")]
        [MaxLength(60)]
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string Photo { get; set; }
        public string About { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
    }
}