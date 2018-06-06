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
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.#}", ApplyFormatInEditMode = true)]
        public double Time { get; set; }
        public TaskStatus Status { get; set; }
        public double ExpectedTime { get; set; }
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