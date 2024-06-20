using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.API.Controllers;

[Route("api/")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _product;
    public ProductController(IProductService productDto) => _product = productDto;

    [HttpGet]
    [Route("products")]
    public async Task<ResponseResult<List<ProductModel>>> GetAllProducts()
    {
        return await _product.GetAllProducts();
    }


    [HttpPost]
    [Route("products")]
    public async Task<ResponseModel> CreateProduct(ProductModel model)
    {
        return await _product.CreateProduct(model);
    }


    [HttpPut]
    [Route("products/{id}")]
    public async Task<ResponseModel> UpdateProduct(ProductModel model, int id)
    {
        return await _product.UpdateProduct(model, id);
    }


    [HttpDelete]
    [Route("products/{id}")]
    public async Task<ResponseModel> DeleteProduct(int id, int userId)
    {
        return await _product.DeleteProduct(id, userId);
    }
}
