using System;
namespace ASPNETProjectgamestop.Models
{
	public class Product
	{

        public int ProductID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
        public string? Description { get; set; }
        public string? Platform { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}
//created new product class and created properties from my column names from sql database
