using System;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Interfaces
{
    public interface IUserActionService
    {
        int RecordAction(string UserId, UserActionType type);
    }
}
