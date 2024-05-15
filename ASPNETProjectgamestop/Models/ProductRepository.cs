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

        public Product AssignCategory() // used for creation of new product and assigning the category
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;

        }

        public IEnumerable<Product> GetAllProducts() 
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;"); //with use of dapper this returns all products created or stored in sql database
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;"); //returns all categories
        }

        public Product GetProduct(int id)// created for clicking on the id to go to that products page
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public void InsertProduct(Product productToInsert) //inserts new product information to sql server
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, STOCKLEVEL, ONSALE, DESCRIPTION, PLATFORM, CATEGORYID) VALUES (@name, @price, @stockLevel, @onSale, @description, @platform, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, stockLevel = productToInsert.StockLevel, onSale = productToInsert.OnSale, description = productToInsert.Description, platform = productToInsert.Platform, categoryID = productToInsert.CategoryID });

        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price, StockLevel = @stockLevel WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, stockLevel = product.StockLevel, id = product.ProductID });
        }

        public void DeleteProduct(Product product)
        {
            
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                                       new { id = product.ProductID });
        }


    }
}// created a class that conforms to the interface and provides the properties implementation

