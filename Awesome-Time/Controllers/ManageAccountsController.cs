using System.Web;
using System.Web.Mvc;
using Awesome_Time.Interfaces;

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
    }
}