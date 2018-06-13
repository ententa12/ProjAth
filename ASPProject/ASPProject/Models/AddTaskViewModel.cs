using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPProject.Models
{
    public class AddTaskViewModel
    {
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string Descryption { get; set; }
        [Display(Name = "Przewidywany czas")]
        public int ExpectedTime { get; set; }

    }
}