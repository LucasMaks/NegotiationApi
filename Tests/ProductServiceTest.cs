using System.Collections.Generic;
using Xunit;
using NegotiationApi.Models;
using NegotiationApi.Services;

public class ProductServiceTests
{
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productService = new ProductService();
    }

    [Fact]
    public void AddProduct_Should_Add_Product_To_List()
    {
        var product = new Products { Name = "Laptop", Price = 2500 };

        _productService.AddProduct(product);
        var products = _productService.GetProducts();

        Assert.Contains(products, p => p.Name == "Laptop" && p.Price == 2500);
    }

    [Fact]
    public void AddProduct_Should_Throw_Exception_When_Name_Is_Empty()
    {
        var product = new Products { Name = "", Price = 2500 };

        Assert.Throws<System.ArgumentException>(() => _productService.AddProduct(product));
    }

    [Fact]
    public void GetProducts_Should_Return_Empty_List_When_No_Products()
    {
        var products = _productService.GetProducts();

        Assert.Empty(products);
    }
}