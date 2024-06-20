using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Entity;
using OnlineStore.API.Data.Entity.DbSet;
using OnlineStore.API.Data.Models;
using OnlineStore.API.Repository.Interface;

namespace OnlineStore.API.Repository.Service;

public class OrderRepository : IOrderRepository
{
    private readonly OnlineStoreDbContext _db;

    public OrderRepository(OnlineStoreDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task<ResponseModel> CreateOrder(OrderModel model)
    {
        try
        {
            var checkProductStock = CheckProductStock(model.OrderItems);
            if (checkProductStock.IsSuccess)
            {

                var orderItems = new List<OrderItem>();
                var products = new List<Product>();
                var totalPrice = 0.0M;

                var productIds = model.OrderItems.Select(oi => oi.ProductId).ToList();
                var productsList = _db.Products.Where(p => productIds.Contains(p.Id)).ToList();

                foreach (var orderItem in model.OrderItems)
                {
                    var product = productsList.Where(p => p.Id == orderItem.ProductId).First();
                    product.Stock -= orderItem.Quantity;
                    products.Add(product);

                    orderItems.Add(new OrderItem()
                    {
                        Price = product.Price,
                        ProductId = orderItem.ProductId,
                        Quantity = orderItem.Quantity,
                    });

                    totalPrice += orderItem.Quantity * product.Price;
                }
                var order = new Order()
                {
                    UserId = model.UserId,
                    TotalPrice = totalPrice,
                    Status = model.Status,
                    CreatedAt = DateTime.UtcNow
                };
                await _db.Orders.AddAsync(order);
                await _db.SaveChangesAsync();

                orderItems.ForEach(x => x.OrderId = order.Id);

                _db.Products.UpdateRange(products);
                await _db.OrderItems.AddRangeAsync(orderItems);
                await _db.SaveChangesAsync();
                return new ResponseModel(true, "Order created successfully.", StatusCodes.Status201Created);
            }
            else
            {
                return checkProductStock;
            }
        }
        catch (Exception ex)
        {
            return new ResponseModel(false, "Something went wrong. Please try again after some time.", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseResult<List<OrderModel>>> GetOrders(int userId)
    {
        var result = new ResponseResult<List<OrderModel>>();
        try
        {
            var orders = await _db.Orders.Where(x => x.UserId == userId).ToListAsync();

            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status200OK;
            result.Data = new List<OrderModel>();
            result.Message = "Orders fetched successfully.";
            foreach (var order in orders)
            {

                result.Data.Add(new OrderModel()
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                    UserId = order.UserId,
                    Status = order.Status,
                    CreatedAt = order.CreatedAt
                });
            }
        }
        catch (Exception ex)
        {
            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status500InternalServerError;
            result.Message = "Something went wrong. Please try again after some time.";
        }
        return result;
    }

    public async Task<ResponseResult<List<OrderItemModel>>> GetOrderDetails(int id)
    {
        var result = new ResponseResult<List<OrderItemModel>>();
        try
        {
            var orders = await _db.OrderItems.Where(x => x.OrderId == id).ToListAsync();
            var ids = orders.Select(x => x.ProductId).ToList();
            var products = _db.Products.Where(x => ids.Contains(x.Id)).ToList();
            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Orders fetched Successfully.";
            result.Data = new List<OrderItemModel>();
            foreach (var order in orders)
            {
                var product = products.Where(x => x.Id == order.ProductId).FirstOrDefault();
                var orderItem = new OrderItemModel()
                {
                    Id = order.Id,
                    Price = order.Price,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    OrderId = order.OrderId,
                    Product = new ProductModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    }
                };
                result.Data.Add(orderItem);
            }
        }
        catch (Exception ex)
        {
            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status500InternalServerError;
            result.Message = "Something went wrong. Please try again after some time.";
        }
        return result;
    }

    private ResponseModel CheckProductStock(List<OrderItemModel> itemsList)
    {
        var isOutofStock = false;
        var message = string.Empty;
        foreach (var order in itemsList)
        {
            var product = _db.Products.Where(x => x.Id == order.ProductId).FirstOrDefault() ?? new Product();
            if (product.Stock is 0)
                message += product.Name + " is out of stock.";

            var remainingStock = product.Stock - order.Quantity;

            if (remainingStock < 0)
            {
                isOutofStock = true;
                message += " Only " + product.Stock + " quantity of " + product.Name + " is available and ordered quantity is " + order.Quantity + ".";
            }
        }
        return new ResponseModel(!isOutofStock, message, StatusCodes.Status200OK);
    }
}
