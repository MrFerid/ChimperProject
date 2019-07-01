using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.Models.ViewModel
{
    public class IndexViewModel
    {
        public Company Company { get; set; }
        public List<Service> Service { get; set; }
        public List<Portfolio> Portfolio { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Blog> Blog { get; set; }
        public string Cover { get; set; }
    }
}