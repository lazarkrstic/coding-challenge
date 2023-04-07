using Microsoft.AspNetCore.Mvc;
using TheShop.Application.Articles.Commands.BuyArticle;
using TheShop.Application.Articles.Queries.GetArticle;
using TheShop.Application.Articles.Queries.GetArticleAvailability;
using TheShop.Application.Articles.Queries.SearchForArticle;
using TheShop.Application.Common.Exceptions;
using TheShop.Application.Common.Models;

namespace Vendor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ApiControllerBase
    {

        /// <summary>
        /// Check the availability
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpHead(Name = nameof(ArticleInInventory))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ArticleInInventory([FromQuery] GetArticleAvailabilityQuery query)
        {
            bool availabe = await Mediator.Send(query);
            if(availabe)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="getArticleQuery"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetArticle))]
        public async Task<ActionResult<ArticleDto>> GetArticle([FromQuery] GetArticleQuery getArticleQuery)
        {
            try
            {
                ArticleDto articleDto = await Mediator.Send(getArticleQuery);
                return articleDto;
            }
            catch (ArticleNotExistException ex)
            {

                return NotFound(ex.Message);
            }
        }


        /// <summary>
        /// By article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <param name="buyArticleCommand"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(BuyArticle))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> BuyArticle(uint id, [FromBody] BuyArticleCommand buyArticleCommand)
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