using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome_Time.Enumerations;
using Awesome_Time.Interfaces;
using Awesome_Time.Entities;
using Microsoft.AspNet.Identity;

namespace Awesome_Time.Services
{
    public class UserActionService : IUserActionService
    {
        ApplicationDbContext db;

        public UserActionService(ApplicationDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Records a user action and returns record Id. Returns 0 when email is invalid.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>Id of new record or 0</returns>
        public int RecordAction(string email, UserActionType type)
        {
            var userId = db.Users.FirstOrDefault(x => x.Email == email)?.Id;

            if(String.IsNullOrWhiteSpace(userId))
            {
                return 0;
            }

            var newUserAction = new UserAction
            {
                ApplicationUserId = userId,
                Date = DateTime.Now,
                Type = type
            };

            db.UserActions.Add(newUserAction);

            db.SaveChanges();

            return newUserAction.Id;
        }
    }
}