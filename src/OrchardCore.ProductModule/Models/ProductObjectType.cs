using GraphQL.Types;

namespace OrchardCore.ProductModule.Models
{
    public class ProductObjectType : ObjectGraphType<Product>
    {
        public ProductObjectType()
        {
            Name = "Product";
            
            Field(x => x.ProductName);
            Field(x => x.ProductPrice);
        }
    }
}
