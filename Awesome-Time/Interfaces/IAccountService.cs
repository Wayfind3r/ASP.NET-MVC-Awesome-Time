using System;
using Awesome_Time.ViewModels;
using System.Collections.Generic;
using Awesome_Time.ServiceClasses.AccountServiceClasses;
using Awesome_Time.Entities;

namespace Awesome_Time.Interfaces
{
    public interface IAccountService
    {
        UpdateAccountResult UpdateAccount(UpdateAccountViewModel model);

        AccountTableViewModel GetAccounts(string email, int page, int pageSize);

        bool TryRegisterAccount(ApplicationUser user, string plainPassword);
    }
}
