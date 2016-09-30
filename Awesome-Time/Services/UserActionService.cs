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

        public int RecordAction(UserActionType type)
        {
            var userID = HttpContext.Current.User.Identity.GetUserId();

            var newUserAction = new UserAction
            {
                ApplicationUserId = userID,
                Date = DateTime.Now,
                Type = type
            };

            db.UserActions.Add(newUserAction);

            db.SaveChanges();

            return newUserAction.Id;
        }
    }
}