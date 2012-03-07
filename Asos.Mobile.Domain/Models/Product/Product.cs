using System.Collections.Generic;

namespace Asos.Mobile.Domain.Models.Product
{
    /// <summary>
    /// Due to Json naming convention Product is physically named RootObject
    /// </summary>
    public class RootObject
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
        public string Sku { get; set; }
        public string Title { get; set; }
        public string AdditionalInfo { get; set; }
        public List<AssociatedProduct> AssociatedProducts { get; set; }
        public string CareInfo { get; set; }
        public string Description { get; set; }
        public List<Variant> Variants { get; set; }
    }
}
