using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome_Time.ServiceClasses.AccountServiceClasses
{
    public class UpdateAccountResult
    {
        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}