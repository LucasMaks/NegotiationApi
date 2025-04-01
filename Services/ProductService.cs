using NegotiationApi.Models;
using NegotiationApi.Services.Interfaces;

namespace NegotiationApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Products> _Product = new List<Products>();
        public void AddProduct(Products products)
        {
            if (string.IsNullOrEmpty(products.Name) || products.Price <= 0)
                throw new ArgumentException("Invalid product data");
          
            products.Id = _Product.Count + 1;
            _Product.Add(products);
        }

        public Products GetProductById(int id) => _Product.FirstOrDefault(p => p.Id == id); 
      

        public IEnumerable<Products> GetProducts() => _Product;
    }
}
