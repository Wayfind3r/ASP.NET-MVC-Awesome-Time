using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Entities
{
    public class UserAction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserActionType Type { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set;}
    }
}