using Awesome_Time.ServiceClasses.ArticleServiceClasses;
using System.Collections.Generic;

namespace Awesome_Time.Interfaces
{
    public interface IArticleService
    {
        int Create(ArticleServiceModel model);

        List<ArticleServiceModel> GetLatestArticles(int count = 4);

        List<ArticleServiceModel> GetLatestArticlePreviews(int count = 4);
    }
}
