using Awesome_Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awesome_Time.Controllers
{
    public class HomeController : Controller
    {
        IArticleService articleService;

        public HomeController(IArticleService service)
        {
            articleService = service;
        }

        public ActionResult Index()
        {
            var model = articleService.GetLatestArticlePreviews();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }
    }
}