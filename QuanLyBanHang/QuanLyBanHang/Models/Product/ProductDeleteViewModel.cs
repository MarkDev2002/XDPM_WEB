using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Product
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }
        public string proName { get; set; }
        public string ImageUrl { get; set; }
    }
}
