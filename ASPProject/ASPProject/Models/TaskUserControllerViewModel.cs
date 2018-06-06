using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TaskUserControllerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.#}", ApplyFormatInEditMode = true)]
        [Display(Name = "Czas")]
        public double Time { get; set; }
        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }
        [Display(Name = "Przewidywany czas")]
        public double ExpectedTime { get; set; }
        [Display(Name = "Nazwa zespołu")]
        public string TeamName { get; set; }
        public bool InWork { get; set; }
    }

    public class TaskWorkViewModel
    {
        public TaskUserControllerViewModel Task { get; set; }
        public List<WorkViewModel> Works { get; set; }

        public TaskWorkViewModel()
        {
            Works = new List<WorkViewModel>();
        }
    }

}