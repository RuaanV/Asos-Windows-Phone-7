using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Asos.Mobile.Domain.Browsing.Api;
using Asos.Mobile.Domain.Models.Product;
using Asos.Mobile.Domain.Properties;
using Newtonsoft.Json;

namespace Asos.Mobile.Domain.Browsing
{
    /// <summary>
    /// Defines the implementation fo the Asos shop against Asos' Api interface as defined http://developer.asos.com
    /// </summary>
    public class AsosShop : ShopBase
    {
        /// <summary>
        /// Asos Uri Constant to get product detail by querying a specific product Id
        /// {0} = Inventory Id
        /// {1} = Locale
        /// {2} = Currency
        /// </summary>
        public const string AsosBaseProductInformationUri = "http://api1.asos.com/product/{0}/{1}/{2}";

        /// <summary>
        /// Asos Uri Constant to list a collection of products>
        /// <remarks>http://developer.asos.com/docs/read/scenarios/category_and_search/Get_products_for_a_particular_category</remarks>
        /// </summary>
        public const string AsosBaseProductListingUri = "http://api1.asos.com/productlisting/category/{0}/{1}/{2}/{3}/{4}";

        /// <summary>
        /// Get child categories for a given caregory or floor id.
        /// <remarks>http://developer.asos.com/docs/read/scenarios/category_and_search/Get_subcategories_for_a_category_or_floor</remarks>
        /// </summary>
        public const string AsosBaseSubCategoryUri = "http://api1.asos.com/subcategorylisting/{0}/{1}/{2}";

        /// <summary>
        /// Asos Uri Constant to list a collection of products using a search term
        /// {0} = Search Term
        /// {1} = Page Number
        /// {2} = Sort By
        /// {3} = Locale
        /// {4} = Currency
        /// <remarks>http://developer.asos.com/docs/read/scenarios/category_and_search/Get_products_using_search</remarks>
        /// </summary>
        public const string AsosBaseProductSearchUri = "http://api1.asos.com/productlisting/search/{0}/{1}/{2}/{3}/{4}";

        /// <summary>
        /// Add the App Specific Key to the Uri required for the request
        /// </summary>
        public const string AsosKeyParameter = "?api_key={0}";

        /// <summary>
        /// Build the refinement options if required for the product query
        /// </summary>
        public const string AsosRefineOptions = "?op={5}";

        protected string ProductJsonData = string.Empty;

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public RootObject Product { get; set; }

        /// <summary>
        /// Gets or sets the product query details.
        /// </summary>
        /// <value>The product query details.</value>
        public List<RootObject> Products { get; set; }

        string AddAsosKeyParameter()
        {
            return string.Format(AsosKeyParameter, ApplicationKeys.ApiKey);
        }

        string BuildAsosProductQueryByIdUri(string inventoryId)
        {
            return string.Format(AsosBaseProductInformationUri, inventoryId, ApplicationKeys.EnglishLocale,
                                 Currencies.GBP) + AddAsosKeyParameter();
        }

        string BuildAsosProductQueryBySearchTerm(string searchTerm)
        {
            return string.Format(AsosBaseProductSearchUri, searchTerm, 1, ProductResultsSortBy.none, ApplicationKeys.EnglishLocale,
                                 Currencies.GBP) + AddAsosKeyParameter(); //TODO Add Sort By and Refinement Options to Domain
        }

        /// <summary>
        /// Get product information for display to the end user from Asos' Api gateway
        /// </summary>
        /// <param name="searchParam"></param>
        /// <param name="queryType"></param>
        /// <remarks>http://developer.asos.com/docs/read/scenarios/category_and_search/Get_products_using_search</remarks>
        /// <remarks>http://developer.asos.com/docs/read/scenarios/category_and_search/Get_products_for_a_particular_category</remarks>
        /// <remarks>http://developer.asos.com/docs/read/scenarios/product/Get_information_about_a_product</remarks>
        /// <returns></returns>
        public override void GetProducts(string searchParam, ProductQueryType queryType)
        {
            switch (queryType)
            {
                case ProductQueryType.ProductByIdQuery:
                    GetProductById(searchParam);
                    break;
                case ProductQueryType.ProductBySearchTerm:
                    GetProductsBySearchTerm(searchParam);
                    break;
                case ProductQueryType.ProductByCategory:
                    GetProductsByCategory(searchParam);
                    break;
            }
        }

        public override void GetProductInformation(string productId)
        {
            GetProductById(productId);
        }

        private void GetProductById(string productId)
        {
            RetrievedDataSuccessfully = false;
            //Intiate new HTTP Web Request to return to non UI Thread 
            var request = WebRequest.Create(BuildAsosProductQueryByIdUri(productId));
            request.BeginGetResponse(ProductCallback, request);

        }

        private void GetProductsBySearchTerm(string searchTerm)
        {
            RetrievedDataSuccessfully = false;
            //Intiate new HTTP Web Request to return to non UI Thread 
            var request = WebRequest.Create(BuildAsosProductQueryBySearchTerm(searchTerm));
            request.BeginGetResponse(ProductCallback, request);
        }

        private void GetProductsByCategory(string searchTerm)
        {
            RetrievedDataSuccessfully = false;
            //Intiate new HTTP Web Request to return to non UI Thread 
            var request = WebRequest.Create(BuildAsosProductQueryBySearchTerm(searchTerm));
            request.BeginGetResponse(ProductCallback, request);
        }

        private void ProductCallback(IAsyncResult result)
        {
            try
            {
                var request = (HttpWebRequest)result.AsyncState;
                var response = request.EndGetResponse(result);

                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    ProductJsonData = reader.ReadToEnd();
                }

                Product = BuildProductData(ProductJsonData);
                RetrievedDataSuccessfully = true;

            }
            finally
            {
                RaiseCompletedCallEvent();
            }
        }

        RootObject BuildProductData(string data)
        {
            //Check data is not null
            if (data == null)
                throw new ArgumentException(Resource.NullJsonData);
            return JsonConvert.DeserializeObject<RootObject>(data);
        }

    }
}
