using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Cart
{
    public class CartAddViewModel
    {
        public int proID { get; set; }
        public string proName { get; set; }
        public string proSize { get; set; }

        public long proPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Producer { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public Gender forGender { get; set; }
        public long availableQuantity { get; set; }
    }
}
