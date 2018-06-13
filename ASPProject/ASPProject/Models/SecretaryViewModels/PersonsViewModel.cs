using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Models.SecretaryViewModels
{
    public enum Roles
    {
        [Display(Name = "Użytkownik")]
        User,
        [Display(Name = "Dyrektor")]
        Director,
        [Display(Name = "Sekretariat")]
        Secretary
    }

    public class PersonsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Pole wymagane")]
        [Remote("CheckExistingEmail", "Secretary", HttpMethod = "POST", ErrorMessage = "Email nie może się powtarzać")]
        public string Email { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Pole wymagane")]
        public Roles Roles { get; set; }
    }
}