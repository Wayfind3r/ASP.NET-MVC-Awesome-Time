using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Awesome_Time.ServiceClasses;

namespace Awesome_Time.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Family Name")]
        public string FamilyName { get; set; }

        [MaxLength(80)]
        [Display(Name ="Twitter Account")]
        public string TwitterAccount { get; set; }

        [Required]
        [MaxLength(12)]
        [Display(Name = "Awesomeness Number", Description = "Awesomeness Number {year (4 digits)}BA-{3 utility digits}{2 English characters}")]
        [RegularExpression(@"^[0-9]{4}BA-[0-9]{3}[a-zA-Z]{2}$", ErrorMessage = "Awesomeness Number format is: {{year (4 digits)}}BA-{{3 utility digits}}{{2 English characters}}")]
        public string AwesomenessNumber { get; set; }

        [Range(typeof(bool), "true","true", ErrorMessage ="Please agree to our Terms and Conditions")]
        public bool AgreeToTermsAndConditions { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class UpdateAccountViewModel
    {
        public UpdateAccountViewModel()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "New Password", Description = "Optional")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Description = "Optional")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [MaxLength(80)]
        [Display(Name = "Twitter Account")]
        public string TwitterAccount { get; set; }

        [Required]
        [MaxLength(12)]
        [Display(Name = "Awesomeness Number", Description = "{year (4 digits)}BA-{3 utility digits}{2 English characters}")]
        [RegularExpression(@"^[0-9]{4}BA-[0-9]{3}[a-zA-Z]{2}$", ErrorMessage = "Awesomeness Number format is: {{year (4 digits)}}BA-{{3 utility digits}}{{2 English characters}}")]
        public string AwesomenessNumber { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
    }

    public class AccountTableViewModel
    {
        private AccountTableViewModel(){}
        public AccountTableViewModel(List<AccountTableRowViewModel> tableContent, int totalItems, int page, int pageSize, string emailFilter)
        {
            Content = tableContent;
            Pager = new Pager(totalItems, page, pageSize);
            EmailFilter = emailFilter;
        }

        public List<AccountTableRowViewModel> Content { get; set; }

        public Pager Pager { get; set; }

        public string EmailFilter { get; set; }
    }

    public class AccountTableRowViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [MaxLength(80)]
        [Display(Name = "Twitter Account")]
        public string TwitterAccount { get; set; }

        [Required]
        [MaxLength(12)]
        [Display(Name = "Awesomeness Number", Description = "Awesomeness Number {year (4 digits)}BA-{3 utility digits}{2 English characters}")]
        [RegularExpression(@"^[0-9]{4}BA-[0-9]{3}[a-zA-Z]{2}$", ErrorMessage = "Awesomeness Number format is: {{year (4 digits)}}BA-{{3 utility digits}}{{2 English characters}}")]
        public string AwesomenessNumber { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
    }
}
