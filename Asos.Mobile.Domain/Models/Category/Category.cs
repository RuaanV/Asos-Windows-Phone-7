using System.Collections.Generic;

namespace Asos.Mobile.Domain.Models.Category
{
    public class RootObject
    {
        public string Description { get; set; }
        public List<Listing> Listing { get; set; }
        public string SortType { get; set; }
    }
}
