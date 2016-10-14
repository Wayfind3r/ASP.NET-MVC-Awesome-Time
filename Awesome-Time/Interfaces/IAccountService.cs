using System;
using System.Collections.Generic;
using Awesome_Time.ServiceClasses.AccountServiceClasses;
using Awesome_Time.Entities;

namespace Awesome_Time.Interfaces
{
    public interface IAccountService
    {
        UpdateAccountServiceResult UpdateAccount(UpdateAccountServiceModel model);

        AccountTableServiceModel GetAccounts(string email, int page, int pageSize);

        UpdateAccountServiceModel GetAccountViewModel(string accountId);

        int GetNumberOfAccounts(string email);

        List<AccountLoginStatisticServiceModel> GetAccountsLoginStatistic(string email, int page, int pageSize);

        List<AccountLoginStatisticServiceModel> GetAccountsLoginStatistic(string email);
    }
}
