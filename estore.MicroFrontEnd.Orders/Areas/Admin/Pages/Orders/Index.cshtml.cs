using estore.MicroFrontEnd.Orders.Models;
using estore.MicroFrontEnd.Orders.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace estore.MicroFrontEnd.Orders.Areas.Admin.Pages.Orders
{
    [Authorize(Policy = "Admin")]
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
            List<Order> _orders = await _orderService.GetAllOrdersAsync();

            Orders = _orders.OrderByDescending(o => o.Date).ToList();
        }
    }
}
