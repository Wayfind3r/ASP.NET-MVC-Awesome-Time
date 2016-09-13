using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awesome_Time;
using Awesome_Time.Services;
using NUnit.Framework;
using Moq;
using Awesome_Time.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Awesome_Time.ViewModels;
using Awesome_Time.Enumerations;

namespace Awesome_Time.Tests.ServiceTests
{
    [TestFixture]
    class AccountServiceTests
    {
        [Test]
        public void GetAccounts()
        {
            // Arrange
            var data = new List<ApplicationUser>
            {
                new ApplicationUser { Email = "administrator@ggbg.com", RegistrationDate = DateTime.Now.AddMonths(-1)},
                new ApplicationUser { Email = "administrator@abv.bg", RegistrationDate = DateTime.Now.AddMonths(-3) },
                new ApplicationUser { Email = "someoneelse@gmail.bg", RegistrationDate = DateTime.Now },
            }.AsQueryable();

            var dbSetMock = new Mock<IDbSet<ApplicationUser>>();
            dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var customDbContextMock = new Mock<ApplicationDbContext>();
            customDbContextMock
                .Setup(x => x.Users)
                .Returns(dbSetMock.Object);
            var service = new AccountService(customDbContextMock.Object);

            // Act
            var result = service.GetAccounts("admin", 1, 10);

            // Assert
            Assert.AreEqual(result.Pager.TotalItems, 2);
        }
        
    }
}
