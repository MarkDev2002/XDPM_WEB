using QuanLyBanHang.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanHang.Models.Product
{
    public class ProductCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product's name is required")]
        public string proName { get; set; }

        [Required(ErrorMessage = "Product's size is required")]
        public string proSize { get; set; }

        [Required(ErrorMessage = "Product's price is required")]
        public long proPrice { get; set; }
        public int? proDiscount { get; set; }
        
        public IFormFile ImageUrl { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime proUpdateDate { get; set; } = DateTime.UtcNow;

        public string? proDescription { get; set; }

        [Required(ErrorMessage = "Producer is required")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Product's status is required")]
        public Status proStatus { get; set; }
        [Required(ErrorMessage = "This information is required")]
        public Gender forGender { get; set; }
        public float? Rate { get; set; }
    }
}
