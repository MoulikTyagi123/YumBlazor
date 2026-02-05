using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class OrderHeader
    {
        public int Id { get; set; }

        [Required]
        public double OrderTotal { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Fixed: removed extra semicolon

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }



        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}