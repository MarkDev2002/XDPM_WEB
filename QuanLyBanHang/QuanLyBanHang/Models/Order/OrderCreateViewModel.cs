using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Order
{
    public class OrderCreateViewModel
    {
        
        public int orderID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Customer's phone  is unvalid")]
        public string cusPhone { get; set; }
        [Required(ErrorMessage = "Customer's address  is unvalid")]
        public string cusAddress { get; set; }
        public string? orderMessage { get; set; }
        public long orderTotal { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public DateTime orderDateTime { get; set; } = DateTime.UtcNow;

        public OrderStatus orderStatus { get; set; }
    }

}
