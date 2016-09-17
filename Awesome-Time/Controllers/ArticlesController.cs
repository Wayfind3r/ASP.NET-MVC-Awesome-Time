using Awesome_Time.Interfaces;
using Awesome_Time.ServiceClasses.ArticleServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awesome_Time.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ArticlesController : Controller
    {
        IArticleService articleService;

        public ArticlesController(IArticleService service)
        {
            articleService = service;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ArticleServiceModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            articleService.Create(model);

            return RedirectToAction("Index", "Home");
        }
    }
}