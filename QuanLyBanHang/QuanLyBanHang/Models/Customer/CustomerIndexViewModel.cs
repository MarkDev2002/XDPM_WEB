using QuanLyBanHang.Entity;

namespace QuanLyBanHang.Models.Customer
{
    public class CustomerIndexViewModel
    {
        public string UserName { get; set; }
        public string cusPhone { get; set; }
        public string cusFullName { get; set; }
        public string cusEmail { get; set; }
        public string cusAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Gender Gender { get; set; }
    }
}
