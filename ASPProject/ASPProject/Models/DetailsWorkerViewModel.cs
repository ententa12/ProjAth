using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class WorkViewModel
    {
        public DateTime? Date { get; set; }
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }
    }

    public class TaskSupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public TaskStatus Status { get; set; }
        public double ExpectedTime { get; set; }
        public string TeamName { get; set; }
        public int Id { get; set; }
    }

    public class TaskSupExtendedViewModel : TaskSupViewModel
    {
        public List<WorkViewModel> Works { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public TaskSupExtendedViewModel()
        {
            Works = new List<WorkViewModel>();
        }
    }

    public class DetailsWorkerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Team> Teams { get; set; }
        public List<TaskSupViewModel> Tasks { get; set; }


        public DetailsWorkerViewModel()
        {
            Teams = new List<Team>();
            Tasks = new List<TaskSupViewModel>();
        }
    }
}