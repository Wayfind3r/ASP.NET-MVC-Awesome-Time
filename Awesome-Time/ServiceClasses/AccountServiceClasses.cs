using System;
using System.Collections.Generic;
using Awesome_Time.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Awesome_Time.ServiceClasses.AccountServiceClasses
{
    public class UpdateAccountServiceResult
    {
        public AccountUpdateResult Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }

    public class AccountTableServiceModel
    {
        private AccountTableServiceModel() { }
        public AccountTableServiceModel(List<AccountTableRowServiceModel> tableContent, int totalItems, int page, int pageSize, string emailFilter)
        {
            Content = tableContent;
            Pager = new Pager(totalItems, page, pageSize);
            EmailFilter = emailFilter;
        }

        public List<AccountTableRowServiceModel> Content { get; set; }

        public Pager Pager { get; set; }

        public string EmailFilter { get; set; }
    }

    public class AccountTableRowServiceModel
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

    public class UpdateAccountServiceModel
    {
        public UpdateAccountServiceModel()
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
}