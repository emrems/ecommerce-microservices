using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommetListByProductId(string id)
        {
            return await _httpClient
                .GetFromJsonAsync<List<ResultCommentDto>>(
                    $"Comments/commentListByProductId/{id}");
        }


        public async Task CreateCommentAsync(CreateCommentDto dto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments", dto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync($"Comments?id={id}");
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            
            var response = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");
            return response!;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"Comments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values!;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto dto)
        {
            
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comments", dto);
        }
    }
}
