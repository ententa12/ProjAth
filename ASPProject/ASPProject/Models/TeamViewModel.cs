using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }



    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public List<TeamMemberViewModel> Members { get; set; }
        public List<TeamTaskViewModel> Tasks { get; set; }

        public TeamViewModel()
        {
            Members = new List<TeamMemberViewModel>();
            Tasks = new List<TeamTaskViewModel>();
        }
    }
}