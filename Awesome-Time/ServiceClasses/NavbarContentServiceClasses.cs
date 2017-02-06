using Awesome_Time.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Awesome_Time.ServiceClasses
{
    public class NavbarContentServiceClasses
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Link { get; set; }

        public NavbarContentType Type { get; set; }

        public int? ParentId { get; set; }
    }
}