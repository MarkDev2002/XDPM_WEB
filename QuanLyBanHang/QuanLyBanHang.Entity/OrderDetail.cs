using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Entity
{
    public class OrderDetail
    {
        [Key]
        public int orderID { get; set; }

        [Key]
        public int proID { get; set; }

        public int ordtsQuantity { get; set; }

        public long ordtsTotal { get; set; }
        public long ordtsItemPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
