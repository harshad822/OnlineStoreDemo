﻿using OnlineStore.API.Data.Models;

namespace OnlineStore.API.DataOperation.Interface;

public interface IProductService
{
    public Task<ResponseResult<List<ProductModel>>> GetAllProducts();
    public Task<ResponseModel> CreateProduct(ProductModel model);
    public Task<ResponseModel> UpdateProduct(ProductModel model, int id);
    public Task<ResponseModel> DeleteProduct(int id, int userId);
}
