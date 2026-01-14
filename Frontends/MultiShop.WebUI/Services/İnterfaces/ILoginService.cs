using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace MultiShop.WebUI.Services.İnterfaces
{
    public interface ILoginService
    {
        public string GetUserId { get; }
    }
}
