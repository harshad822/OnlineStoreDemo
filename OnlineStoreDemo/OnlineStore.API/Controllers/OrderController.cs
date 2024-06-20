using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;

        public OrderController(IOrderService orderDto)
        {
            _order = orderDto;
        }

        [HttpPost]
        [Route("orders")]
        public async Task<ResponseModel> CreateOrder(OrderModel model)
        {
            return await _order.CreateOrder(model);
        }

        [HttpGet]
        [Route("orders")]
        public async Task<ResponseResult<List<OrderModel>>> GetOrders(int userId)
        {
            return await _order.GetOrders(userId);
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<ResponseResult<List<OrderItemModel>>> GetOrderDetails(int id)
        {
            return await _order.GetOrderDetails(id);
        }
    }

}
