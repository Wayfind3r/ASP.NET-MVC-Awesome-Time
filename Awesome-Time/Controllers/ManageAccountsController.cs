﻿using System.Web;
using System.Web.Mvc;
using Awesome_Time.Interfaces;
using Awesome_Time.ServiceClasses.AccountServiceClasses;
using System.Linq;
using Awesome_Time.ViewModels;

namespace Awesome_Time.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageAccountsController : Controller
    {
        IAccountService accountService;

        public ManageAccountsController(IAccountService service)
        {
            accountService = service;
        }

        // GET: ManageAccounts
        public ActionResult List(int page = 1, int pageSize = 10, string email = "")
        {
            var model = accountService.GetAccounts(email, page, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string accountId)
        {
            var model = accountService.GetAccountViewModel(accountId);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(UpdateAccountServiceModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = accountService.UpdateAccount(model);

            if(result.Succeeded == Enumerations.AccountUpdateResult.InvalidPassword)
            {//Add password error to model errors, if password did not pass validation
                ModelState.AddModelError("NewPassword", result.Errors.ToList()[0]);
                return View(model);

            }
            if(result.Succeeded == Enumerations.AccountUpdateResult.Failed)
            {
                model.Errors = result.Errors.ToList();
                return View(model);
            }
            
            return RedirectToAction("List", new { email = model.Email });
        }

        public ActionResult LoginStatistic(int page = 1, int pageSize = 10, string email = "")
        {
            var total = accountService.GetNumberOfAccounts(email);

            var list = accountService.GetAccountsLoginStatistic(email, page, pageSize);

            var model = new AccountsLoginStatisticTableViewModel(list, total, page, pageSize, email);

            return View(model);
        }
    }
}