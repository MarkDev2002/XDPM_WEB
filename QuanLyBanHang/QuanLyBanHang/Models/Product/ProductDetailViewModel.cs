using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanHang.Models.Product
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        public string proName { get; set; }

        public string proSize { get; set; }

        public long proPrice { get; set; }
        public int? proDiscount { get; set; }
        public string ImageUrl { get; set; }
        public DateTime proUpdateDate { get; set; }

        public string? proDescription { get; set; }

        public string Producer { get; set; }

        public Status proStatus { get; set; }
        public Gender forGender { get; set; }
        public float? Rate { get; set; }
    }
}
