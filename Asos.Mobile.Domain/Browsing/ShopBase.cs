using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Asos.Mobile.Domain.Interface;
using Asos.Mobile.Domain.Models;
using Asos.Mobile.Domain.Models.Product;

namespace Asos.Mobile.Domain.Browsing
{
    /// <summary>
    /// Delegate for implementation
    /// </summary>
    public delegate void CompletedCallDelegate();

    /// <summary>
    /// Base class defining methods for Shop definition classes
    /// </summary>
    public abstract class ShopBase : IShopBase
    {
        /// <summary>
        /// Enumeration for the different product query categorisations
        /// </summary>
        public enum ProductQueryType
        {
            /// <summary>
            /// Query By Product Indentifier
            /// </summary>
            ProductByIdQuery = 0,
            /// <summary>
            /// Query by String search term <example>Red Jeans</example>
            /// </summary>
            ProductBySearchTerm = 1,
            /// <summary>
            /// Query by Product Category <example>Dress, though </example>
            /// </summary>
            ProductByCategory = 2
        }

        /// <summary>
        /// Gets the product.<remarks>provider specific implementation required</remarks>
        /// </summary>
        /// <param name="searchParam">The search param.</param>
        /// <param name="queryType">Type of the query.</param>
        /// <returns></returns>
        public abstract void GetProducts(string searchParam, ProductQueryType queryType);

        /// <summary>
        /// Gets the product information.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public abstract void GetProductInformation(string productId);  

        /// <summary>
        /// Gets or sets a value indicating whether a schedule has been retrieved successfully.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [retrieved schedule successfully]; otherwise, <c>false</c>.
        /// </value>
        public bool RetrievedDataSuccessfully { get; set; }

        /// <summary>
        /// Occurs when internal calls are completed to allow the UI to update to a not processing state.
        /// </summary>
        public event CompletedCallDelegate CompletedAsynchCall;

        /// <summary>
        /// Raises the completed call event.
        /// </summary>
        protected void RaiseCompletedCallEvent()
        {
            if (CompletedAsynchCall != null)
                CompletedAsynchCall();
        }
    }
}
