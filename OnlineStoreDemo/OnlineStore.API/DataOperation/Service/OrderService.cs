using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using OnlineStore.API.Repository.Interface;

namespace OnlineStore.API.DataOperation.Service;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _order;

    public OrderService(IOrderRepository order)
    {
        _order = order;
    }

    public Task<ResponseModel> CreateOrder(OrderModel model)
    {
        return _order.CreateOrder(model);
    }

    public Task<ResponseResult<List<OrderItemModel>>> GetOrderDetails(int id)
    {
        return _order.GetOrderDetails(id);
    }

    public Task<ResponseResult<List<OrderModel>>> GetOrders(int userId)
    {
        return _order.GetOrders(userId);
    }
}
