using System;
using System.Collections.Generic;
using System.Linq;
using Awesome_Time.Interfaces;
using Awesome_Time.ServiceClasses.ArticleServiceClasses;
using Awesome_Time.Entities;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Text.RegularExpressions;

namespace Awesome_Time.Services
{
    public class ArticleService : IArticleService
    {
        ApplicationDbContext db;

        public ArticleService(ApplicationDbContext context)
        {
            db = context;
        }

        public int Create(ArticleServiceModel model)
        {
            var userID = HttpContext.Current.User.Identity.GetUserId();

            var entity = new Article
            {
                SubmitDate = DateTime.Now,
                Title = model.Title,
                Body = model.Body,
                ApplicationUserId = userID
            };

            db.Articles.Add(entity);
            db.SaveChanges();

            return entity.Id;
        }

        public List<ArticleServiceModel> GetLatestArticles(int count = 4)
        {
            var result = db.Articles.OrderByDescending(x => x.SubmitDate)
                .Take(count)
                .Select(x => new ArticleServiceModel
                {
                    Body = x.Body,
                    Title = x.Title
                }).ToList();

            return result;
        }

        public List<ArticleServiceModel> GetLatestArticlePreviews(int count = 4)
        {
            var result = GetLatestArticles(count);

            foreach (var article in result)
            {
                article.Body = GeneratePreviewFromHtml(article.Body);
            }

            return result;
        }

        private const int _previewLength = 60;

        private string GeneratePreviewFromHtml(string htmlString)
        {
            //Remove Html
            var result = Regex.Replace(htmlString, @"<[^>]*>", String.Empty);
            //result = Regex.Replace(htmlString, @"&nbsp;", " ");
            //result = Regex.Replace(htmlString, @"&ldquo;|&rdquo;", "\"");

            //Get preview length
            var length = result.Length < _previewLength ? result.Length : _previewLength;

            //Crop string to preview length
            result = result.Substring(0, length);
            //Remove last word to ensure the last word is full in half and add ...
            var lastIndexOfSpace = result.LastIndexOf(" ");
            if(lastIndexOfSpace != -1)
            {//space found
                result = result.Substring(0, lastIndexOfSpace);
            }

            result = result + "...";

            return result;
        }
    }
}