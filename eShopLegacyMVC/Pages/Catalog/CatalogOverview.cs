using System;
using System.Collections.Generic;
using eShopLegacyMVC.Models;
using eShopLegacyMVC.Services;
using Microsoft.AspNetCore.Components;

namespace eShopLegacyMVC.Pages.Catalog
{
    public partial class CatalogOverview
    {
        [Inject]
        private ICatalogService _service { get; set; }

        public PaginatedItemsViewModel<CatalogItem> CatalogItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        protected override void OnInitialized()
        {
            PageIndex = 0;
            PageSize = 10;
            InitializeCatalog();

            base.OnInitialized();
        }

        private void InitializeCatalog()
        {
            CatalogItems = _service.GetCatalogItemsPaginated(PageSize, PageIndex);
        }

        protected void Previous()
        {
            PageIndex--;
            InitializeCatalog();
        }

        protected void Next()
        {
            PageIndex++;
            InitializeCatalog();
        }
    }
}
