using Cart.API.Entities;
using Cart.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cart.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{userName}", Name ="GetCart")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetCart(string userName)
        {
            var cart = await _repository.GetCart(userName);

            return Ok(cart ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateCart([FromBody] ShoppingCart cart)
        {
            return Ok(await _repository.UpdateCart(cart));
        }

        [HttpDelete("{userName}", Name ="DeleteCart")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCart(string userName)
        {
            await _repository.DeleteCart(userName);

            return Ok();
        }
    }
}
