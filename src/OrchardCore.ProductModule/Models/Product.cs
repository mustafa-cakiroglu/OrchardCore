using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.ContentManagement;

namespace OrchardCore.ProductModule.Models
{
    public class Product : ContentPart
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
