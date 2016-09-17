using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Awesome_Time.ServiceClasses.ArticleServiceClasses
{
    public class ArticleServiceModel
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(5000)]
        // This attributes allows your HTML Content to be sent up
        [AllowHtml]
        public string Body { get; set; }
    }
}