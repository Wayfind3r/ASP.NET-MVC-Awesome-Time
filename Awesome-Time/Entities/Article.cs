using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome_Time.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SubmitDate { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}