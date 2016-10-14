using System;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Interfaces
{
    public interface IUserActionService
    {
        /// <summary>
        /// Records a user action and returns record Id. Returns 0 when email is invalid.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>Id of new record or 0</returns>
        int RecordAction(string email, UserActionType type);
    }
}
