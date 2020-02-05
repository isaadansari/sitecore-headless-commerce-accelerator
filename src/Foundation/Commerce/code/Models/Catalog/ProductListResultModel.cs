//    Copyright 2019 EPAM Systems, Inc.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

namespace Wooli.Foundation.Commerce.Models.Catalog
{
    using System.Collections.Generic;
    using Connect.Models;
    using Sitecore.Commerce.Engine.Connect.Search.Models;
    using Sitecore.Diagnostics;
    using TypeLite;

    [TsClass]
    public class ProductListResultModel
    {
        public string CurrentCatalogItemId { get; set; }

        public string SearchKeyword { get; set; }

        public int? MaxPageSize { get; set; }

        public int CurrentPageNumber { get; set; }

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }

        public IList<ProductModel> ChildProducts { get; set; }

        public IList<FacetResultModel> Facets { get; set; }

        public IList<SortOptionModel> SortOptions { get; set; }

        public void Initialize(CommerceSearchOptions commerceSearchOptions, SearchResults searchResults,
            IList<ProductModel> productEntityList, string searchKeyword = null)
        {
            Assert.ArgumentNotNull(commerceSearchOptions, nameof(commerceSearchOptions));
            Assert.ArgumentNotNull(searchResults, nameof(searchResults));
            Assert.ArgumentNotNull(productEntityList, nameof(productEntityList));

            MaxPageSize = commerceSearchOptions.NumberOfItemsToReturn;
            SearchKeyword = searchKeyword; // commerceSearchOptions.SearchKeyword

            CurrentPageNumber = searchResults.CurrentPageNumber;
            TotalItemCount = searchResults.TotalItemCount;
            TotalPageCount = searchResults.TotalPageCount;

            ChildProducts = productEntityList ?? new List<ProductModel>();

            var facets = new List<FacetResultModel>();
            foreach (CommerceQueryFacet queryFacet in searchResults.Facets)
            {
                var facetModel = new FacetResultModel();
                facetModel.Initialize(queryFacet);
                facets.Add(facetModel);
            }

            Facets = facets;
        }
    }
}