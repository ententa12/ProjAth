using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPProject.Models
{
    //    public class ExternalLoginConfirmationViewModel
    //    {
    //        [Required]
    //        [Display(Name = "Email")]
    //        public string Email { get; set; }
    //    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    //    public class SendCodeViewModel
    //    {
    //        public string SelectedProvider { get; set; }
    //        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    //        public string ReturnUrl { get; set; }
    //        public bool RememberMe { get; set; }
    //    }

    //    public class VerifyCodeViewModel
    //    {
    //        [Required]
    //        public string Provider { get; set; }

    //        [Required]
    //        [Display(Name = "Code")]
    //        public string Code { get; set; }
    //        public string ReturnUrl { get; set; }

    //        [Display(Name = "Remember this browser?")]
    //        public bool RememberBrowser { get; set; }

    //        public bool RememberMe { get; set; }
    //    }

    //    public class ForgotViewModel
    //    {
    //        [Required]
    //        [Display(Name = "Email")]
    //        public string Email { get; set; }
    //    }

    public class LoginViewModel
{
    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Hasło")]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}

    //    public class RegisterViewModel
    //    {
    //        [Required]
    //        [EmailAddress]
    //        [Display(Name = "Email")]
    //        public string Email { get; set; }

    //        [Required]
    //        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //        [DataType(DataType.Password)]
    //        [Display(Name = "Password")]
    //        public string Password { get; set; }

    //        [DataType(DataType.Password)]
    //        [Display(Name = "Confirm password")]
    //        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //        public string ConfirmPassword { get; set; }
    //    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło:")]
        [RegularExpression(@"^(?=.*[a-zA-Z]{2})(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Hasło musi posiadać min: 8 znaków, 2 litery, 1 dużą literę, 1 cyfrę")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz Hasło")]
        [Compare("Password", ErrorMessage = "Powtórzone hasło nie zgadza się")]
        public string ConfirmPassword { get; set; }
    }
    public class UserDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }

    //    public class ForgotPasswordViewModel
    //    {
    //        [Required]
    //        [EmailAddress]
    //        [Display(Name = "Email")]
    //        public string Email { get; set; }
    //    }
}
