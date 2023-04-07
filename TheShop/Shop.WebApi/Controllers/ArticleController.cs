using System;
using Microsoft.AspNetCore.Mvc;
using TheShop.Application.Articles.Commands.BuyArticle;
using TheShop.Application.Articles.Queries.SearchForArticle;
using TheShop.Application.Common.Exceptions;
using TheShop.Application.Common.Models;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ApiControllerBase
    {

        /// <summary>
        /// Get article by Id.
        /// </summary>
        /// <param name="searchForArticleQuery"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetArticle))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ArticleDto>> GetArticle([FromQuery] SearchForArticleQuery searchForArticleQuery)
        {

            try
            {
                ArticleDto articleDto = await Mediator.Send(searchForArticleQuery);
                return articleDto;
            }
            catch (ArticleNotExistException ex)
            {

                return NotFound(ex.Message);
            }
 
        }


        /// <summary>
        /// Buy Article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <param name="buyArticleCommand"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(BuyArticle))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> BuyArticle(uint id, [FromBody] BuyArticleCommand buyArticleCommand )
        {

            if (id != buyArticleCommand.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(buyArticleCommand);
            return CreatedAtAction(nameof(BuyArticle), nameof(ArticleController), id);
        }
    }
}