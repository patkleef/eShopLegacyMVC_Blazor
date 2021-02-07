using System.Linq;
using eShopLegacyMVC.Services;
using Microsoft.AspNetCore.Components;

namespace eShopLegacyMVC.Components
{
    public partial class CatalogStatistics
    {
        public CatalogStatisticsViewModel Model { get; set; }

        [Inject]
        private ICatalogService _service { get; set; }

        protected override void OnInitialized()
        {
            Model = new CatalogStatisticsViewModel
            {
                NumberOfBrands = _service.GetCatalogBrands().Count(),
                NumberOfCategories = _service.GetCatalogTypes().Count(),
                NumberOfItems = (int)_service.GetCatalogItemsPaginated(1000, 0).TotalItems
            };

            base.OnInitialized();
        }
    }
}
