using ASPProject.BL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPProject.Entities
{
    public enum TaskStatus
    {
        [Display(Name = "Porzucone")]
        abandoned,
        [Display(Name = "Oczekujące")]
        waiting,
        [Display(Name = "W trakcie")]
        inProgress,
        [Display(Name = "Zakończone")]
        finished
    }


    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public TaskStatus Status { get; set; }
        public double ExpectedTime { get; set; }

        public int? UserId { get; set; }
        public virtual UserDetails CurrentUser { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Work> Works { get; set; }

        public Task()
        {
            Works = new HashSet<Work>();
        }
    }
}