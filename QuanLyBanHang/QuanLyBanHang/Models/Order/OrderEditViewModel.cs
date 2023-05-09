using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Order
{
    public class OrderEditViewModel
    {
        public int orderID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Customer's phone  is unvalid")]
        public long orderTotal { get; set; }

        public DateTime orderDateTime { get; set; }

        public OrderStatus orderStatus { get; set; }
    }
}
