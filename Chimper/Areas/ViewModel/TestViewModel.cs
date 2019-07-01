using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.Areas.ViewModel
{
    public class TestViewModel
    {
        public Testimonials Test { get; set; }
        public List<Testimonials> Tests { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}