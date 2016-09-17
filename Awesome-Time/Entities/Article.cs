using System;
using System.ComponentModel.DataAnnotations;

namespace Awesome_Time.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Body { get; set; }
        public DateTime SubmitDate { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}