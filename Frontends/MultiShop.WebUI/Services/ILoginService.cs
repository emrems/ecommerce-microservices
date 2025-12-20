using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace MultiShop.WebUI.Services
{
    public interface ILoginService
    {
        public string GetUserId { get; }
    }
}
