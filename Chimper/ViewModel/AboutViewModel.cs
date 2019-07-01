using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.ViewModel
{
    public class AboutViewModel
    {
        public Company Company { get; set; }
        public List<Specialties> Specialties { get; set; }
        public List<Team> Team { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Covers>  Cover { get; set; }
    }

}