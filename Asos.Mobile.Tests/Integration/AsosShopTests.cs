using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Asos.Mobile.Domain.Browsing;
using Asos.Mobile.Domain.Models;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asos.Mobile.Tests.Integration
{
    public class AsosShopTests
    {
        [TestClass]
        public class QueryProductsTests : SilverlightTest
        {
            [Asynchronous]
            [TestMethod]
            [Tag("Integration")]
            public void GetProductById()
            {
                const string productId = "1703489"; //Test product id for integration testing
                //Arrange
                var asosShop = new AsosShop();
                asosShop.CompletedAsynchCall += () =>
                {
                    try
                    {
                        //Assert
                        Assert.IsTrue(
                        asosShop.RetrievedDataSuccessfully,
                        "Failed to retrieve JSON from Uri");
                        Assert.IsNotNull(asosShop.Product, "Product has a null value for the productId query");
                        Assert.IsTrue(asosShop.Product.ProductId == int.Parse(productId), "Invalid product returned for Product Id Query");

                    }
                    finally
                    {
                        EnqueueTestComplete();
                    }
                };
                ////Act  
                asosShop.GetProductInformation(productId);

            }

            [Asynchronous]
            [TestMethod]
            [Tag("Integration")]
            public void GetProductBySearchTerm()
            {
                const string searchParam = "Dress"; //Test search term for integration testing
                //Arrange
                var asosShop = new AsosShop();
                asosShop.CompletedAsynchCall += () =>
                {
                    try
                    {
                        //Assert
                        Assert.IsTrue(
                        asosShop.RetrievedDataSuccessfully,
                        "Failed to retrieve JSON from Uri");
                        Assert.IsNotNull(asosShop.Product, "Products have a null value for the search query");
                        //TODO: Finalise assert to test search correlates to product

                    }
                    finally
                    {
                        EnqueueTestComplete();
                    }
                };
                ////Act  
                asosShop.GetProducts(searchParam, ShopBase.ProductQueryType.ProductBySearchTerm);

            }
        }

    }
}
