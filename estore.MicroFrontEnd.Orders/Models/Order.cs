#nullable disable
using System.ComponentModel.DataAnnotations;

namespace estore.MicroFrontEnd.Orders.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [MaxLength(250)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Qty")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Cost")]
        public decimal UnitCost { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Id")]
        [MaxLength(50)]
        public string CustomerId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Name")]
        [MaxLength(250)]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Email")]
        [MaxLength(250)]
        public string CustomerEmail { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Shipping Address")]
        [MaxLength(350)]
        public string ShippingAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Transaction Id")]
        [MaxLength(50)]
        public string TransactionId { get; set; }
    }
}

