using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chimper.Models
{
    public class Company
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Company adini yazin")]
        [MaxLength(100,ErrorMessage = "Kompanya adi 100 herfden cox ola bilmez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email adresini yazin")]
        [EmailAddress(ErrorMessage = "Email adresi duzgun deyil")]
        [MaxLength(60, ErrorMessage = "Email en cox 60 herfden ibaret ola biler")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Unvani yazin")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Shirket haqqinda bir sheyler yazin")]
        public string About { get; set; }
        public string Photo { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }

    }
}