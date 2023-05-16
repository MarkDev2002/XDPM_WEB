using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuanLyBanHang.Models.Order;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Service;
using QuanLyBanHang.Models.Product;

namespace QuanLyBanHang.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private IWebHostEnvironment _webHostEnvironment;
        public OrderController(IProductService productService, 
            IOrderService orderService, 
            IWebHostEnvironment webHostEnvironment, 
            IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _webHostEnvironment = webHostEnvironment;
            _orderDetailService = orderDetailService;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _orderService.GetAll().Select(order => new OrderIndexViewModel
            {
                UserName = order.UserName,
                orderID = order.orderID,
                cusPhone = order.cusPhone,
                orderMessage = order.orderMessage,
                orderDateTime = order.orderDateTime,
                orderStatus = order.orderStatus,
                orderTotal = order.orderTotal,
                cusAddress = order.cusAddress,
                paymentMethod = order.paymentMethod,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {            
            var order = _orderService.GetById(id);
            var orderDetail = _orderDetailService.GetAll().Where(p => p.orderID == id);
            if (order == null)
            {
                return NotFound();
            }
            if (orderDetail == null)
            {
                return NotFound();
            }
            var model = orderDetail.Select(od => new OrderDetailViewModel
            {
                UserName = order.UserName,
                orderID = order.orderID,
                cusPhone = order.cusPhone,
                orderMessage = order.orderMessage,
                orderDateTime = order.orderDateTime,
                orderTotal = order.orderTotal,
                cusAddress= order.cusAddress,
                orderStatus = order.orderStatus,
                proImage = _productService.GetById(od.proID).ImageUrl,
                proName = _productService.GetById(od.proID).proName,
                proID = od.proID,
                ordtsQuantity = od.ordtsQuantity,
                ordtsTotal = od.ordtsTotal,
                ordtsItemPrice = od.ordtsItemPrice,
                paymentMethod = order.paymentMethod,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateStatus(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = new OrderEditViewModel
            {
                UserName = order.UserName,
                orderID = order.orderID,
                orderTotal = order.orderTotal,
                orderDateTime = order.orderDateTime,
                orderStatus = order.orderStatus,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(OrderEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = _orderService.GetById(model.orderID);

                order.orderStatus = model.orderStatus;

                await _orderService.UpdateAsSync(order);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SortedByDate(string sortOrder)
        {
            var model = _orderService.GetAll().Select(order => new OrderIndexViewModel
            {
                UserName = order.UserName,
                orderID = order.orderID,
                cusPhone = order.cusPhone,
                orderMessage = order.orderMessage,
                orderDateTime = order.orderDateTime,
                orderStatus = order.orderStatus,
                orderTotal = order.orderTotal,
                cusAddress = order.cusAddress,
                paymentMethod = order.paymentMethod,
            }).ToList();
            switch (sortOrder)
            {
                case "desc":
                    return View(model.OrderByDescending(ord => ord.orderDateTime).ToList());
                case "inc":
                    return View(model.OrderBy(ord => ord.orderDateTime).ToList());
            }
            return View(model);

        }
    }
}
