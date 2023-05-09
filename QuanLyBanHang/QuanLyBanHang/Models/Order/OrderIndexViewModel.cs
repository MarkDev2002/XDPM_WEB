using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Models.Order
{
    public class OrderIndexViewModel
    {
        public int orderID { get; set; }

        public string UserName { get; set; }
        public string cusPhone { get; set; }

        public string? orderMessage { get; set; }
        public string cusAddress { get; set; }
        public long orderTotal { get; set; }
        public PaymentMethod paymentMethod { get; set; }

        public DateTime orderDateTime { get; set; }

        public OrderStatus orderStatus { get; set; }
    }
}
