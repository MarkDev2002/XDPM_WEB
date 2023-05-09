using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }

        public string proName { get; set; }

        public string proSize { get; set; }

        public long proPrice { get; set; }

        public string ImageUrl { get; set; }

        public DateTime proUpdateDate { get; set; }

        public string Producer { get; set; }
        public Status proStatus { get; set; }
        public Gender forGender { get; set; }
    }
}
