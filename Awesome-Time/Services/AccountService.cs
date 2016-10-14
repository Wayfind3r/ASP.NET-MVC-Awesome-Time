using Awesome_Time.Interfaces;
using Awesome_Time.Entities;
using Awesome_Time.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Awesome_Time.ServiceClasses.AccountServiceClasses;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Services
{
    public class AccountService : IAccountService
    {
        ApplicationDbContext db;

        public AccountService(ApplicationDbContext context)
        {
            db = context;
        }

        public AccountTableServiceModel GetAccounts(string email, int page, int pageSize)
        {
            var query = db.Users.AsQueryable();

            if (!String.IsNullOrWhiteSpace(email))
            {
                query = query.Where(x => x.Email.Contains(email));
            }

            var tableContent = query
                .Select(u => new AccountTableRowServiceModel
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
            .OrderBy(x=>x.RegistrationDate)
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .ToList();

            var totalResults = query.Count();

            var result = new AccountTableServiceModel(tableContent, totalResults, page, pageSize, email);

            return result;
        }

        public UpdateAccountServiceModel GetAccountViewModel(string accountId)
        {
            var applicationUserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = applicationUserManager.FindById(accountId);

            var result = new UpdateAccountServiceModel
            {
                AwesomenessNumber = user.AwesomenessNumber,
                TwitterAccount = user.TwitterAccount,
                NewPassword = null,
                ConfirmPassword = null,
                Email = user.Email,
                FamilyName = user.FamilyName,
                GivenName = user.GivenName,
                PhoneNumber = user.PhoneNumber,
                RegistrationDate = user.RegistrationDate,
                UserId = user.Id,
                Errors = new List<string>()
            };

            return result;
        }

        public UpdateAccountServiceResult UpdateAccount(UpdateAccountServiceModel model)
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

            var result = new UpdateAccountServiceResult
            {
                Succeeded = AccountUpdateResult.Failed,
                Errors = new List<string>()
            };

            if(!string.IsNullOrEmpty(model.NewPassword) && model.NewPassword == model.ConfirmPassword)
            {
                //Validate password
                var validatePasswordResult = applicationUserManager.PasswordValidator.ValidateAsync(model.NewPassword).Result;

                if(validatePasswordResult.Succeeded)
                {
                    user.PasswordHash = applicationUserManager.PasswordHasher.HashPassword(model.NewPassword);
                    //Update User and change password
                    var updateResult = applicationUserManager.UpdateAsync(user).Result;
                    result.Succeeded = (AccountUpdateResult)Convert.ToInt32(updateResult.Succeeded);
                    result.Errors = updateResult.Errors;
                }
                else
                {
                    result.Succeeded = AccountUpdateResult.InvalidPassword;
                    result.Errors = validatePasswordResult.Errors;
                }
            }
            else
            {//Update user without changing password
                var updateResult = applicationUserManager.UpdateAsync(user).Result;
                result.Succeeded = (AccountUpdateResult)Convert.ToInt32(updateResult.Succeeded);
                result.Errors = updateResult.Errors;
            }

            return result;
        }

        public int GetNumberOfAccounts(string email)
        {
            var result = 0;
            if(String.IsNullOrWhiteSpace(email))
            {
                result = db.Users.Count();

                return result;
            }

            var emailFilter = email.Trim();

            result = db.Users
                .Where(x => x.Email.Contains(emailFilter))
                .Count();

            return result;
        }

        public List<AccountLoginStatisticServiceModel> GetAccountsLoginStatistic(string email)
        {
            var result = new List<AccountLoginStatisticServiceModel>();

            IQueryable<ApplicationUser> query;

            if(!String.IsNullOrWhiteSpace(email))
            {
                var emailFilter = email.Trim();

                query = db.Users.Where(x => x.Email.Contains(emailFilter));
            }
            else
            {
                query = db.Users.AsQueryable();
            }

            result = query.OrderByDescending(x => x.RegistrationDate)
                    .Select(x => new AccountLoginStatisticServiceModel
                    {
                        Email = x.Email,
                        FullName = x.GivenName + " " + x.FamilyName,
                        LastLoginDate = x.UserActions.
                            Where(action => action.Type == UserActionType.Login)
                            .OrderByDescending(action => action.Date)
                            .FirstOrDefault()
                            .Date,
                        RegistrationDate = x.RegistrationDate,
                        TotalLogins = x.UserActions
                            .Where(action => action.Type == UserActionType.Login)
                            .Count(),
                        UserId = x.Id,
                        UserTier = x.UserTier.ToString()
                    }).ToList();

            return result;
        }

        public List<AccountLoginStatisticServiceModel> GetAccountsLoginStatistic(string email, int page, int pageSize)
        {
            var result = new List<AccountLoginStatisticServiceModel>();

            IQueryable<ApplicationUser> query;

            if (!String.IsNullOrWhiteSpace(email))
            {
                var emailFilter = email.Trim();

                query = db.Users.Where(x => x.Email.Contains(emailFilter));
            }
            else
            {
                query = db.Users.AsQueryable();
            }

            result = query.OrderByDescending(x => x.RegistrationDate)
                    .Skip((page-1)*pageSize)
                    .Take(pageSize)
                    .Select(x => new AccountLoginStatisticServiceModel
                    {
                        Email = x.Email,
                        FullName = x.GivenName + " " + x.FamilyName,
                        LastLoginDate = x.UserActions.
                            Where(action => action.Type == UserActionType.Login)
                            .OrderByDescending(action => action.Date)
                            .FirstOrDefault()
                            .Date,
                        RegistrationDate = x.RegistrationDate,
                        TotalLogins = x.UserActions
                            .Where(action => action.Type == UserActionType.Login)
                            .Count(),
                        UserId = x.Id,
                        UserTier = x.UserTier.ToString()
                    }).ToList();

            return result;
        }
    }
}