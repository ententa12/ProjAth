using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
    }



    public class TeamViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Szef")]
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