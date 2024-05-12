using System;
namespace ASPNETProjectgamestop.Models
{
	public class Product
	{
		public Product()
		{
		}


        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
    }
}

