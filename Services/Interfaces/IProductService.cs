using NegotiationApi.Models;

namespace NegotiationApi.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Products products);
        IEnumerable<Products> GetProducts();
        Products GetProductById(int id);
    }
}
