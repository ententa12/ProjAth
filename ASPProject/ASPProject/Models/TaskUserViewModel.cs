using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TaskUserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Nazwa zespołu")]
        public string TeamName { get; set; }
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }
        public bool InWork { get; set; }
    }
}