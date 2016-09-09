using Awesome_Time.Interfaces;
using Awesome_Time.Entities;
using Awesome_Time.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Awesome_Time.ServiceClasses.AccountServiceClasses;

namespace Awesome_Time.Services
{
    public class AccountService : IAccountService
    {
        ApplicationDbContext db;

        public AccountService(ApplicationDbContext context)
        {
            db = context;
        }

        public IPagedList<AccountTableViewModel> GetAccounts(string email, int page, int pageSize)
        {
            var result = db.Users.Select(u => new AccountTableViewModel
            {
                AwesomenessNumber = u.AwesomenessNumber,
                TwitterAccount = u.TwitterAccount,
                Email = u.Email,
                FamilyName = u.FamilyName,
                GivenName = u.GivenName,
                PhoneNumber = u.PhoneNumber,
                RegistrationDate = u.RegistrationDate,
                UserId = u.Id
            })
            .ToPagedList(page, pageSize);

            return result;
        }

        public UpdateAccountResult UpdateAccount(UpdateAccountViewModel model)
        {
            var applicationUserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = applicationUserManager.FindById(model.UserId);

            user.Email = model.Email;
            user.FamilyName = model.FamilyName;
            user.AwesomenessNumber = model.AwesomenessNumber;
            user.GivenName = model.GivenName;
            user.PhoneNumber = model.PhoneNumber;
            user.RegistrationDate = model.RegistrationDate;
            user.TwitterAccount = model.TwitterAccount;
            user.PasswordHash = applicationUserManager.PasswordHasher.HashPassword(model.NewPassword);

            var updateResult = applicationUserManager.UpdateAsync(user).Result;

            var result = new UpdateAccountResult
            {
                Succeeded = updateResult.Succeeded,
                Errors = updateResult.Errors
            };

            return result;
        }

        public bool TryRegisterAccount(ApplicationUser user, string plainPassword)
        {
            var applicationUserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var result = applicationUserManager.CreateAsync(user, plainPassword).Result.Succeeded;

            return result;
        }
    }
}