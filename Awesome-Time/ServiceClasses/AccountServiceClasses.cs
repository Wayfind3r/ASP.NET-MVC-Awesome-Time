using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Awesome_Time.Enumerations;

namespace Awesome_Time.ServiceClasses.AccountServiceClasses
{
    public class UpdateAccountServiceResult
    {
        public AccountUpdateResult Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}