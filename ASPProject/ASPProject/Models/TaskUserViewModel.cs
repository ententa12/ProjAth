using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TaskUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public TaskStatus Status { get; set; }
        public bool InWork { get; set; }
    }
}