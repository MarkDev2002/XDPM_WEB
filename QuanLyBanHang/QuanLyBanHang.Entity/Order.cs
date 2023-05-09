using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Entity
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }

        public string UserName { get; set; }
        public string cusPhone { get; set; }

        public string? orderMessage { get; set; }
        public string cusAddress { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public long orderTotal { get; set; }

        public DateTime orderDateTime { get; set; }

        public OrderStatus orderStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> orderDetail { get; set; }
    }
}
