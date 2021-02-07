using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopLegacyMVC.Models;
using eShopLegacyMVC.Services;
using Microsoft.AspNetCore.Components;

namespace eShopLegacyMVC.Pages.Catalog
{
    public partial class CatalogEdit
    {
        [Parameter]
        public int Id { get; set; }
        public CatalogItem Item { get; set; }
        public IEnumerable<CatalogType> CatalogTypes { get; set; }
        public IEnumerable<CatalogBrand> CatalogBrands { get; set; }

        [Inject]
        private ICatalogService _service { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        protected override void OnInitialized()
        {
            Item = Id == 0 ? new CatalogItem() : _service.FindCatalogItem(Id);
            CatalogTypes = _service.GetCatalogTypes();
            CatalogBrands = _service.GetCatalogBrands();

            base.OnInitialized();
        }

        protected void EditClick()
        {
            if (Item.Id == 0)
            {
                _service.CreateCatalogItem(Item);
            }
            else
            {
                _service.UpdateCatalogItem(Item);
            }
            _navigationManager.NavigateTo("/");
        }
    }
}
