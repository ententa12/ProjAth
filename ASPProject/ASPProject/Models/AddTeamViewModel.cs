using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Models
{
    public class AddTeamViewModel
    {
        public string Name { get; set; }
        public List<SelectListItem> AvailableWorkers { get; set; }
        public List<string> SelectedWorkers { get; set; }

        public AddTeamViewModel()
        {
            AvailableWorkers = new List<SelectListItem>();
            SelectedWorkers = new List<string>();
        }
    }
}