using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        // Badlaav: decimal ki jagah double use karein
        public double Price { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}