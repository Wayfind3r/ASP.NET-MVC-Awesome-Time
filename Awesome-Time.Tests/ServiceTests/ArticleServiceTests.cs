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
using Awesome_Time.ServiceClasses.ArticleServiceClasses;

namespace Awesome_Time.Tests.ServiceTests
{
    [TestFixture]
    class ArticleServiceTests
    {
        [Test]
        public void GetLatestArticlesTest()
        {
            var latestArticleTitle = "One T";
            #region Arrange data
            var data = new List<Article>
            {
                new Article
                {
                    Title = latestArticleTitle,
                    Body = "body one T",
                    SubmitDate = DateTime.Now.AddDays(-1)
                },
                new Article
                {
                    Title = "2 T",
                    Body = "body 2 T",
                    SubmitDate = DateTime.Now.AddDays(-2)
                },
                new Article
                {
                    Title = "3 T",
                    Body = "body 3 T",
                    SubmitDate = DateTime.Now.AddDays(-3)
                },
                new Article
                {
                    Title = "4 T",
                    Body = "body 4 T",
                    SubmitDate = DateTime.Now.AddDays(-4)
                },
                new Article
                {
                    Title = "5 T",
                    Body = "body 5 T",
                    SubmitDate = DateTime.Now.AddDays(-5)
                },
                new Article
                {
                    Title = "6 T",
                    Body = "body 6 T",
                    SubmitDate = DateTime.Now.AddDays(-6)
                }
            }.AsQueryable();
            #endregion

            var dbSetMock = new Mock<DbSet<Article>>();
            dbSetMock.As<IQueryable<Article>>().Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.As<IQueryable<Article>>().Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.As<IQueryable<Article>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.As<IQueryable<Article>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            var mockDbContext = new Mock<ApplicationDbContext>();
            mockDbContext.Setup(x => x.Articles).Returns(dbSetMock.Object);

            // Act
            var service = new ArticleService(mockDbContext.Object);
            var articlecount = 2;
            var result = service.GetLatestArticles(articlecount);

            // Assert
            Assert.AreEqual(result.Count, articlecount);
            Assert.AreEqual(result[0].Title, latestArticleTitle);
        }
    }
}
