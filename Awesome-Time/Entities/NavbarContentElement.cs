using System;
using System.ComponentModel.DataAnnotations;
using Awesome_Time.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awesome_Time.Entities
{
    public class NavbarContentElement
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Link { get; set; }

        public NavbarContentType Type { get; set; }

        public int? ParentId { get; set; }

        public virtual NavbarContentElement Parent { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<NavbarContentElement> Children { get; set; }
    }
}