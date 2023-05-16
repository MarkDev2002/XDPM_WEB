using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLyBanHang.Entity
{
    public class Product
    { 

        [Key]
        public int proID { get; set; }

        public string proName { get; set; }

        public string proSize { get; set; }

        public long proPrice { get; set; }

        public int? proDiscount { get; set; }

        public string ImageUrl { get; set; }

        public DateTime proUpdateDate { get; set; }

        public string? proDescription { get; set; }
        public Status proStatus { get; set; }
        public Gender forGender { get; set; }

        public  string Producer { get; set; }
        public long Quantity { get; set; }
        public ICollection<OrderDetail> orderDetail { get; set; }
    }
}
