using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Entity
{
    public class Customer
    {
        [Key]
        public string nameofUser { get; set; }
        public string cusPhone { get; set; }
        public string cusFullName { get; set; }
        public string cusEmail { get; set; }
        public string cusAddress { get; set; }
        public Gender cusGender { get; set; }
        public virtual ICollection<Cart> CartItems { get; set; }
        public virtual ICollection<Order> OrderList { get; set; }
    }
}
