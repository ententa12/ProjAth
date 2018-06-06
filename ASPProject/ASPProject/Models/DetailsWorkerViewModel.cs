using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TaskSupExtendedViewModel : TaskUserControllerViewModel
    {
        public List<WorkViewModel> Works { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }


        public TaskSupExtendedViewModel()
        {
            Works = new List<WorkViewModel>();
        }
    }

    public class DetailsWorkerViewModel
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Team> Teams { get; set; }
        public List<TaskUserControllerViewModel> Tasks { get; set; }


        public DetailsWorkerViewModel()
        {
            Teams = new List<Team>();
            Tasks = new List<TaskUserControllerViewModel>();
        }
    }
}