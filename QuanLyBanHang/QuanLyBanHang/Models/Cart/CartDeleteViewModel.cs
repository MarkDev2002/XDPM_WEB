using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Cart
{
    public class CartDeleteViewModel
    {
        public string UserName { get; set; }
        public string proName { get; set; }
        public string proImage { get; set; }
        public int proId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}
