using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Order
{
    public class OrderDetailViewModel
    {
        public int orderID { get; set; }

        public string UserName { get; set; }
        public string cusPhone { get; set; }
        public string cusAddress { get; set; }
        public long orderTotal { get; set; }

        public string orderMessage { get; set; }

        public DateTime orderDateTime { get; set; }
        public PaymentMethod paymentMethod { get; set; }

        public OrderStatus orderStatus { get; set; }




        public int proID { get; set; }

        public int ordtsQuantity { get; set; }

        public long ordtsTotal { get; set; }
        public long ordtsItemPrice { get; set; }
        public string proImage { get; set; }
        public string proName { get; set; }
    }
}
