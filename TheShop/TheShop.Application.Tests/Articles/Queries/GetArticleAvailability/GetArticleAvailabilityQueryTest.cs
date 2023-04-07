using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Articles.Queries.GetArticleAvailability;

namespace TheShop.Application.Tests.Articles.Queries.GetArticleAvailability
{
    using static Testing;
    public class GetArticleAvailabilityQueryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ArticleIsAvailable()
        {
            // arrange
            GetArticleAvailabilityQuery query = new GetArticleAvailabilityQuery() { Id = 1 };

            // act
            bool result = await SendAsync(query);

            // assert
            Assert.IsTrue(result);

        }
        [Test]
        public async Task ArticleNotAvailable()
        {
            // arrange
            GetArticleAvailabilityQuery query = new GetArticleAvailabilityQuery() { Id = 2 };

            // act
            bool result = await SendAsync(query);

            // assert
            Assert.IsFalse(result);

        }
    }
}
