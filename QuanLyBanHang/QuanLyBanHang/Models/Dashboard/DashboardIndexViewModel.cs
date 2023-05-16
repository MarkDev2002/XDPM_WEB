namespace QuanLyBanHang.Models.Dashboard
{
    public class DashboardIndexViewModel
    {
        public int cusQuantity { get; set; }
        public long orderTodayQuantity { get; set; }
        public long productQuantity { get; set; }
        public long orderMonthQuantity { get; set; }
        public long earningToday { get; set; }
        public long earningMonth { get; set; }
        public int newCusInMonth { get; set; }
        public int productQuantitySold { get; set; }
        public int totalProQuantity { get; set; }
        public List<long> earningMonths { get; set; } = new List<long>();
    }
}
