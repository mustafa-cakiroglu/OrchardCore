using System.Data;
using OrchardCore.Data.Migration;

namespace OrchardCore.ProductModule.Migrations
{
    public class Migration : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateMapIndexTable("Product", table => table
                .Column<string>("ProductName", column => column.WithLength(50))
                .Column<int>("ProductPrice", column => column.WithLength(10)));
            
            return 1;
        }
    }
}
