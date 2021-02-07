using eShopLegacyMVC.Models;
using eShopLegacyMVC.Services;
using Microsoft.AspNetCore.Components;

namespace eShopLegacyMVC.Pages.Catalog
{
    public partial class CatalogDetails
    {
        public CatalogItem Item { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ICatalogService _service { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        protected override void OnInitialized()
        {
            Item = _service.FindCatalogItem(Id);

            base.OnInitialized();
        }

        protected void DeleteClick()
        {
            var catalogItem = _service.FindCatalogItem(Id);

            _service.RemoveCatalogItem(catalogItem);

            _navigationManager.NavigateTo("/");
        }
    }
}
