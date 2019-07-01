using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chimper.Areas.ViewModel
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public List<Team> Teams { get; set; }
        public string Cover { get; set; }
        public string Header { get; set; }
        public string Action { get; set; }
    }
}