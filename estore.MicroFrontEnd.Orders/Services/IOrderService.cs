using estore.MicroFrontEnd.Orders.Models;

namespace estore.MicroFrontEnd.Orders.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int? id);
        Task DeleteOrderAsync(int? id);
        Task<List<Order>> GetOrdersByCustomerAsync(string id);
    }
}
