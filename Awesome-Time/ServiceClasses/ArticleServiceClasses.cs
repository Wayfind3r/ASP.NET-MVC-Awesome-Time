using System.ComponentModel.DataAnnotations;

namespace Awesome_Time.ServiceClasses.ArticleServiceClasses
{
    public class ArticleServiceModel
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Body { get; set; }
    }
}