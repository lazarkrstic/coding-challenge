using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Articles.Queries.GetArticle;
using TheShop.Application.Common.Exceptions;

namespace TheShop.Application.Tests.Articles.Queries.GetArticle
{
    using static Testing;
    public class GetArticleQueryTest
    {
        [Test]
        public async Task GetArticleAvailable()
        {
            // arrange
            var query = new GetArticleQuery() { Id = 1 };

            // act
            var article = await SendAsync(query);

            // assert
            Assert.IsNotNull(article);
            Assert.That(article.Id, Is.EqualTo(1));

        }

        [Test]
        public async Task GetArticleNotAvailable()
        {
            // arrange
            var query = new GetArticleQuery() { Id = 2 };
            string errorMessageExpected = "Not exist Article with id: 2";

            try
            {
                // act
                var article = await SendAsync(query);
                Assert.Fail();
            }
            catch (ArticleNotExistException ex)
            {
                // assert
                Assert.That(ex.Message, Is.EqualTo(errorMessageExpected));
            }

        }

    }
}
