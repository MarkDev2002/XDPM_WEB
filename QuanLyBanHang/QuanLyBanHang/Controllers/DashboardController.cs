using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.Models.Dashboard;
using QuanLyBanHang.Service;

namespace QuanLyBanHang.Controllers
{
    [Authorize(Roles="Admin")]
    public class DashboardController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private ICustomerService _customerService;
        private IOrderDetailService _orderDetailService;
        public DashboardController(IProductService productService,
            IOrderService orderService,
            ICustomerService customerService,
            IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _orderService = orderService;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            long earningInMonth = 0;
            long earningInDay = 0;
            int productQuantity = 0;
            int totalQuantity = 0;
            var products = _productService.GetAll().ToList();
            foreach(var p in products)
            {
                totalQuantity += (int)p.Quantity;
            }
            var order = _orderService.GetAll().Where(od => od.orderDateTime.Date == DateTime.UtcNow.Date && od.orderDateTime.Year == DateTime.UtcNow.Year).ToList();            
            foreach (var od in order)
            {
                var odtQuantity = (int)_orderDetailService.GetTotalQuantity(od.orderID);
                productQuantity += odtQuantity;
                earningInDay += od.orderTotal;
            }
            var orderMonth = _orderService.GetAll().Where(od => od.orderDateTime.Month == DateTime.UtcNow.Month && od.orderDateTime.Year == DateTime.UtcNow.Year).ToList();
            foreach (var od in orderMonth)
            {
                earningInMonth += od.orderTotal;
            }
            var model = new DashboardIndexViewModel()
            {
                cusQuantity = _customerService.GetAll().Count(),
                orderTodayQuantity = order.Count(),
                orderMonthQuantity = orderMonth.Count(),
                earningToday = earningInDay,
                earningMonth = earningInMonth,
                productQuantitySold = productQuantity,
                totalProQuantity = totalQuantity,
                productQuantity = _productService.GetAll().Count(),
            };
            for(int i = 1; i <= 12; i++)
            {
                var odM = _orderService.GetAll().Where(od => od.orderDateTime.Month == i && od.orderDateTime.Year == DateTime.UtcNow.Year).ToList();
                long earningEachMonth = 0;
                foreach (var od in odM)
                {                    
                    earningEachMonth += od.orderTotal;
                }
                model.earningMonths.Add(earningEachMonth);
            }
            return View(model);
        }
    }
}
