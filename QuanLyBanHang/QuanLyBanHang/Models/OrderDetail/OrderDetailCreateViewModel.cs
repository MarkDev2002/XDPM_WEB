namespace QuanLyBanHang.Models.OrderDetail
{
    public class OrderDetailCreateViewModel
    {
        public int proID { get; set; }

        public int ordtsQuantity { get; set; }

        public long ordtsTotal { get; set; }
        public long ordtsItemPrice { get; set; }
        public string proImage { get; set; }
        public string proName { get; set; }
    }
}
