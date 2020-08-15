using Dapper;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.Data;
using OrchardCore.Environment.Shell;
using OrchardCore.ProductModule.Models;
using System.Collections.Generic;
using System.Linq;
using YesSql;

namespace OrchardCore.ProductModule.Controllers
{
    [Admin]
    public class ProductController : Controller
    {

        private readonly IDbConnectionAccessor _dbAccessor;
        private readonly string _tablePrefix;

        public ProductController(IDbConnectionAccessor dbAccessor, ShellSettings settings)
        {
            _dbAccessor = dbAccessor;
            _tablePrefix = settings["TablePrefix"];
        }

        public ActionResult ProductMain()
        {
            return View(new ProductMainModel());
        }

        [HttpPost]
        [Route("Product/SendDataToPgl")]
        public void SendDataToPgl(ProductMainModel model)
        {
            using (var connection = _dbAccessor.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var dialect = SqlDialectFactory.For(connection);
                    var customTable = dialect.QuoteForTableName($"{_tablePrefix}_Product");
                    var documentId = dialect.QuoteForColumnName($"DocumentId");
                    var productName = dialect.QuoteForColumnName($"ProductName");
                    var productPrice = dialect.QuoteForColumnName($"ProductPrice");

                    connection.Execute($"INSERT INTO {customTable} ({documentId},{productName},{productPrice}) VALUES(1,@ProductName,@ProductPrice)", model);
                    //var amodel = connection.Execute(selectCommand);

                    // If an exception occurs the transaction is disposed and rollbacked
                    transaction.Commit();
                }
            }

        }

        [HttpGet]
        [Route("Product/GetAllProducts/{index}")]
        public List<Product> GetAllProducts(int index)
        {
            var list = new List<Product>();
            using (var connection = _dbAccessor.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var dialect = SqlDialectFactory.For(connection);
                    var customTable = dialect.QuoteForTableName($"{_tablePrefix}_Product");
                    var documentId = dialect.QuoteForColumnName($"DocumentId");

                    var query = $"SELECT * FROM {customTable} WHERE {documentId} = {index}";

                    list = connection.Query<Product>(query).ToList();

                    transaction.Commit();
                }
            }
            return list;
        }
    }
}

