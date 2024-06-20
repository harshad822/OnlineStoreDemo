using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using OnlineStore.API.Repository.Interface;

namespace OnlineStore.API.DataOperation.Service;
public class ProductService : IProductService
{
    private readonly IProductRepository _product;
    public ProductService(IProductRepository productService)
    {
        _product = productService;
    }
    public Task<ResponseModel> CreateProduct(ProductModel model)
    {
        return _product.CreateProduct(model);
    }

    public Task<ResponseModel> DeleteProduct(int id, int userId)
    {
        return _product.DeleteProduct(id, userId);
    }

    public Task<ResponseResult<List<ProductModel>>> GetAllProducts()
    {
        return _product.GetAllProducts();
    }

    public Task<ResponseModel> UpdateProduct(ProductModel model, int id)
    {
        return _product.UpdateProduct(model, id);
    }
}