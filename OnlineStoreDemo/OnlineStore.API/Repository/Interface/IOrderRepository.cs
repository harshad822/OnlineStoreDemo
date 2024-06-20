using OnlineStore.API.Data.Models;

namespace OnlineStore.API.Repository.Interface;
public interface IOrderRepository
{
    public Task<ResponseModel> CreateOrder(OrderModel model);
    public Task<ResponseResult<List<OrderModel>>> GetOrders(int userId);
    public Task<ResponseResult<List<OrderItemModel>>> GetOrderDetails(int id);
}
