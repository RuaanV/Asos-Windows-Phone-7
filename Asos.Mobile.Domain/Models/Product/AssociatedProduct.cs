﻿using System.Collections.Generic;

namespace Asos.Mobile.Domain.Models.Product
{
    public class AssociatedProduct
    {
        public double BasePrice { get; set; }
        public string Brand { get; set; }
        public object Colour { get; set; }
        public string CurrentPrice { get; set; }
        public bool InStock { get; set; }
        public bool IsInSet { get; set; }
        public string PreviousPrice { get; set; }
        public string PriceType { get; set; }
        public int ProductId { get; set; }
        public List<string> ProductImageUrls { get; set; }
        public string RRP { get; set; }
        public object Size { get; set; }
        public object Sku { get; set; }
        public string Title { get; set; }
        public string ProductType { get; set; }
    }
}
