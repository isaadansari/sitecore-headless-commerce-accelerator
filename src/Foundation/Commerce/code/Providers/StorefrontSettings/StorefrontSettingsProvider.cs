﻿//    Copyright 2020 EPAM Systems, Inc.
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

namespace Wooli.Foundation.Commerce.Providers.StorefrontSettings
{
    using System;
    using System.Linq;

    using Connect.Context.Storefront;

    using DependencyInjection;

    using Models.Entities.Addresses;

    using Sitecore.Diagnostics;

    [Service(typeof(IStorefrontSettingsProvider), Lifetime = Lifetime.Singleton)]
    public class StorefrontSettingsProvider : IStorefrontSettingsProvider
    {
        private readonly IStorefrontContext storefrontContext;

        public StorefrontSettingsProvider(IStorefrontContext storefrontContext)
        {
            Assert.ArgumentNotNull(storefrontContext, nameof(storefrontContext));

            this.storefrontContext = storefrontContext;
        }

        public string GetPaymentOptionId(string optionTitle)
        {
            var paymentOptions = this.storefrontContext.StorefrontConfiguration?.PaymentSettings?.SelectedPaymentOptions?.ToList();
            if (paymentOptions != null && paymentOptions.Any())
            {
                var paymentOption = paymentOptions.FirstOrDefault(
                    option => option.Title.Equals(optionTitle, StringComparison.OrdinalIgnoreCase));
                if (paymentOption != null)
                {
                    return paymentOption.Id.ToString("D");
                }
            }

            return string.Empty;
        }
    }
}