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
    using System.Linq;
    using Connect.Models;
    using Sitecore.Diagnostics;
    using TypeLite;

    [TsClass]
    public class CategoryModel
    {
        public string SitecoreId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public IList<string> ParentCatalogList { get; set; }

        public IList<string> ChildrenCategoryList { get; set; }

        public void Initialize(IConnectCategoryModel categoryModel)
        {
            Assert.ArgumentNotNull(categoryModel, nameof(categoryModel));

            SitecoreId = categoryModel.SitecoreId;
            Name = categoryModel.Name;
            DisplayName = categoryModel.DisplayName;
            Description = categoryModel.Description;

            ParentCatalogList = categoryModel.ParentCatalogList?.Split('|').ToList();
            ChildrenCategoryList = categoryModel.ChildrenCategoryList?.Split('|').ToList();
        }
    }
}