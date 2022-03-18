using estore.MicroFrontEnd.Orders.Models;
using estore.MicroFrontEnd.Orders.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace estore.MicroFrontEnd.Orders.Areas.Customer.Pages.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IList<Order> Orders { get; set; } = new List<Order>();

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            string customerId = User?.Claims
               ?.FirstOrDefault(x => x.Type.Equals("http://schemas.microsoft.com/identity/claims/objectidentifier", StringComparison.OrdinalIgnoreCase))
               ?.Value ?? string.Empty;

            List<Order> _orders = await _orderService.GetOrdersByCustomerAsync(customerId);

            Orders = _orders.OrderByDescending(o => o.Date).ToList();
        }
    }
}
