using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class TeamTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}