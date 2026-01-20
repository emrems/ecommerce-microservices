
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommetListByProductId(string id);

        Task CreateCommentAsync(CreateCommentDto dto);
        Task DeleteCommentAsync(string id);
        Task UpdateCommentAsync(UpdateCommentDto dto);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
    }
}
