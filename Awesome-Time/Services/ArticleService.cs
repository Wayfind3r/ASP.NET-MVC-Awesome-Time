using System;
using System.Collections.Generic;
using System.Linq;
using Awesome_Time.Interfaces;
using Awesome_Time.ServiceClasses.ArticleServiceClasses;
using Awesome_Time.Entities;

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
            var entity = new Article
            {
                SubmitDate = DateTime.Now,
                Title = model.Title,
                Body = model.Body
            };

            db.Articles.Add(entity);
            db.SaveChanges();

            return entity.Id;
        }

        public List<ArticleServiceModel> GetLatestArticles(int count)
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
    }
}