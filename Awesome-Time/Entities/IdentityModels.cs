using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [MaxLength(50)]
        public string GivenName { get; set; }
        [MaxLength(50)]
        public string FamilyName { get; set; }
        [MaxLength(80)]
        public string TwitterAccount { get; set; }
        [MaxLength(12)]
        public string AwesomenessNumber { get; set; }

        public UserTier UserTier { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        
        public virtual ICollection<UserAction> UserActions { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<UserAction> UserActions { get; set; }
    }
}