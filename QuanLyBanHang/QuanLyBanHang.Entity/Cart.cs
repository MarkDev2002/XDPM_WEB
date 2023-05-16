using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Entity
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string nameofUser { get; set; }
        public string proName { get; set; }
        public string proImage { get; set; }
        public long proPrice { get; set; }
        public int proId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
