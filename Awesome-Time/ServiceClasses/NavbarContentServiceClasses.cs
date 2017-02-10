using Awesome_Time.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Awesome_Time.NavbarContentServiceClasses
{
    public class NavbarElementViewModel : BaseElementModel
    {
        public int Id { get; set; }

        public List<NavbarElementViewModel> Children { get; set; }
    }

    public class NavbarSingleElementViewModel : BaseElementModel
    {
        public int Id { get; set; }
    }

    public class NavbarNewElementViewModel : BaseElementModel
    {
    }

    public class BaseElementModel
    {
        [MinLength(5)]
        public string Link { get; set; }

        public NavbarContentType Type { get; set; }

        public int? ParentId { get; set; }
    }
}