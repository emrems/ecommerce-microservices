using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent
    {
        private readonly IFutureSliderService _futureSliderService;

        public _CarouselDefaultComponentPartial(IFutureSliderService futureSliderService)
        {
            _futureSliderService = futureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var sliders = await _futureSliderService.GetAllFeatureSliderAsync();
            return View(sliders);
        }
    }
}
