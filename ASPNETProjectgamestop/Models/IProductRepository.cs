using System;
using System.Collections.Generic;
using ASPNETProjectgamestop.Models;

namespace ASPNETProjectgamestop.Models
{
	public interface IProductRepository
	{
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);


    }


}

