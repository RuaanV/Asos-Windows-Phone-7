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

namespace Asos.Mobile.Domain.Models.Category
{
    public class Listing
    {
        public string CategoryGroupName { get; set; }
        public string CategoryId { get; set; }
        public List<object> Facets { get; set; }
        public bool IsAvailableOffline { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
