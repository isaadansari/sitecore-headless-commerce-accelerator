//    Copyright 2020 EPAM Systems, Inc.
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

    using Sitecore.Data.Items;

    using TypeLite;

    [TsClass]
    public class ProductVariantModel : BaseProductModel
    {
        public ProductVariantModel(Item sellableItem)
            : base(sellableItem)
        {
            this.ProductVariantId = sellableItem.Name;

            var properties = new Dictionary<string, string>();
            var variantProperties = sellableItem["VariationProperties"]?.Split('|') ?? new string[0];
            foreach (var variantPropertyName in variantProperties)
            {
                if (!string.IsNullOrEmpty(variantPropertyName))
                {
                    var value = sellableItem[variantPropertyName];
                    properties.Add(variantPropertyName, value);
                }
            }

            this.VariantProperties = properties;
        }

        public string ProductVariantId { get; set; }

        public IDictionary<string, string> VariantProperties { get; set; }
    }
}