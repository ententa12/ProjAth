using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class WorkViewModel
    {
        [Display(Name = "Data")]
        public DateTime? Date { get; set; }
        [Display(Name = "Początek")]
        public TimeSpan? StartHour { get; set; }
        [Display(Name = "Koniec")]
        public TimeSpan? EndHour { get; set; }
    }
}