using Cart.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Cart.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IDistributedCache _redisCache;

        public CartRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task DeleteCart(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetCart(string userName)
        {
            var cart = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(cart))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(cart);
        }

        public async Task<ShoppingCart> UpdateCart(ShoppingCart cart)
        {
            await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));

            return await GetCart(cart.UserName);
        }
    }
}
