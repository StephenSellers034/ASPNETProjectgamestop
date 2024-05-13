using System;
using System.Data;
using Dapper;

namespace ASPNETProjectgamestop.Models
{
	public class ProductRepository : IProductRepository
	{
	
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price, StockLevel = @stocklevl WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, stocklevel = product.StockLevel,  id = product.ProductID });
        }


    }
}

