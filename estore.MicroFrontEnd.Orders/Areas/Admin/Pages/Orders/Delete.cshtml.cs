#nullable disable
using estore.MicroFrontEnd.Orders.Models;
using estore.MicroFrontEnd.Orders.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace estore.MicroFrontEnd.Orders.Areas.Admin.Pages.Orders
{
    [Authorize(Policy = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _orderService;

        [BindProperty]
        public Order Order { get; set; }

        public DeleteModel(IOrderService orderService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderService.GetOrderByIdAsync(id);

            if (Order != null)
            {
               await _orderService.DeleteOrderAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
