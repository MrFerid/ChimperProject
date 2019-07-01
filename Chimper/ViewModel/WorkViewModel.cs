using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.ViewModel
{
    public class WorkViewModel
    {
        public List<Portfolio> Portfolio { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public string Cover { get; set; }
    }
}