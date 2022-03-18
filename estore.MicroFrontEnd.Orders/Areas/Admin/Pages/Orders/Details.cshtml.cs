#nullable disable
using estore.MicroFrontEnd.Orders.Models;
using estore.MicroFrontEnd.Orders.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace estore.MicroFrontEnd.Orders.Areas.Admin.Pages.Orders
{
    [Authorize(Policy = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;

        public Order Order { get; set; }

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderService.GetOrderByIdAsync(id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
