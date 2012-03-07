using System.Collections.Generic;
using Asos.Mobile.Domain.Browsing;
using Asos.Mobile.Domain.Models.Product;

namespace Asos.Mobile.Domain.Interface
{
    public interface IShopBase
    {
        /// <summary>
        /// Occurs when [completed asynch call].
        /// </summary>
        event CompletedCallDelegate CompletedAsynchCall;

        /// <summary>
        /// Gets the product information.
        /// </summary>
        /// <param name="productId">The product id.</param>
        void GetProductInformation(string productId);

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="searchParam">The search param.</param>
        /// <param name="queryType">Type of the query.</param>
        void GetProducts(string searchParam, ShopBase.ProductQueryType queryType);

        /// <summary>
        /// Gets or sets a value indicating whether a schedule has been retrieved successfully.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [retrieved schedule successfully]; otherwise, <c>false</c>.
        /// </value>
        bool RetrievedDataSuccessfully { get; set; }
    }

}
