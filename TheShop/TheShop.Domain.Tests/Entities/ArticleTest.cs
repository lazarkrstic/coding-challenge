using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Entities;

namespace TheShop.Domain.Tests.Entities
{
    public class ArticleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestArticlePropertyValues()
        {
            // arrange
            DateTime dateTime = DateTime.Now;

            // act
            Article article = new Article() { Id = 1, Name = "Article 1", Sold = true, Price = 100, BuyerId = 1, SoldDate = dateTime };


            // assert
            Assert.IsNotNull(article);
            Assert.Multiple(() =>
            {
                Assert.That(article.Id, Is.EqualTo(1));
                Assert.That(article.Name, Is.EqualTo("Article 1"));
                Assert.That(article.Sold, Is.True);
                Assert.That(article.Price, Is.EqualTo(100));
                Assert.That(article.BuyerId, Is.EqualTo(1));
                Assert.That(article.SoldDate, Is.EqualTo(dateTime));
            });
        }
    }
}
