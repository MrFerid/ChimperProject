using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.Areas.ViewModel
{
    public class WorksViewModel
    {
        public Portfolio Portfolio { get; set; }
        public IList<Portfolio> Portfolios { get; set; }
        public string Cover { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}