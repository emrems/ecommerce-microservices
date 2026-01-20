using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var basket = await GetBasket();

            if (basket == null)
            {
                basket = new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto>()
                };
            }

            if (basket.BasketItems == null)
                basket.BasketItems = new List<BasketItemDto>();

            var existItem = basket.BasketItems
                .FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

            if (existItem != null)
            {
                existItem.Quantity += basketItemDto.Quantity;
            }
            else
            {
                basket.BasketItems.Add(basketItemDto);
            }

            await SaveBasket(basket);
        }


        public async Task DeleteBasket(string userId)
        {
            await _httpClient.DeleteAsync($"Baskets/{userId}");
        }

        public async  Task<BasketTotalDto> GetBasket()
        {
            
            var response = await _httpClient.GetAsync("Baskets");
            if (response.IsSuccessStatusCode)
            {
                var basketTotalDto = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
                return basketTotalDto;
            }
            return null;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            if (deletedItem != null)
            {
                values.BasketItems.Remove(deletedItem);
                await SaveBasket(values);
                return true;
            }
            await SaveBasket(values);
            return false;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);
        }
    }
}
