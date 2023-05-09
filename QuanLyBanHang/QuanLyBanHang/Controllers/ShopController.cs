using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuanLyBanHang.Models.Product;
using QuanLyBanHang.Service;
using QuanLyBanHang.Entity;
using Microsoft.AspNetCore.Identity;
using QuanLyBanHang.Service.implementation;
using Microsoft.CodeAnalysis;
using QuanLyBanHang.Models.Cart;
using QuanLyBanHang.Models.Order;

namespace QuanLyBanHang.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private ICartService _cartService;
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public ShopController(IProductService productService,
            IOrderService orderService,
            IWebHostEnvironment webHostEnvironment, 
            ICartService cartService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll().Where(p => p.proStatus == Status.Available).Select(product => new ProductIndexViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proUpdateDate = product.proUpdateDate,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Order() 
        {
            var username = _userManager.GetUserName(User);
            var model = _orderService.GetAll().Where(od => od.UserName == username).Select(order => new OrderIndexViewModel
            {
                orderID = order.orderID,
                UserName = order.UserName,
                cusPhone = order.cusPhone,
                orderMessage = order.orderMessage,
                cusAddress = order.cusAddress,
                orderTotal = order.orderTotal,
                orderDateTime = order.orderDateTime,
                orderStatus = order.orderStatus
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proDiscount = product.proDiscount,
                proUpdateDate = product.proUpdateDate,
                proDescription = product.proDescription,
                Producer = product.Producer,
                Rate = product.Rate,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult SortedByMale()
        {
            var model = _productService.GetAll().Where(p => p.forGender == Gender.Male).Select(product => new ProductIndexViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proUpdateDate = product.proUpdateDate,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult SortedByFemale()
        {
            var model = _productService.GetAll().Where(p => p.forGender == Gender.Female).Select(product => new ProductIndexViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proUpdateDate = product.proUpdateDate,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult SortedByNike()
        {
            var model = _productService.GetAll().Where(p => p.Producer == "Nike").Select(product => new ProductIndexViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proUpdateDate = product.proUpdateDate,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult SortedByAdidas()
        {
            var model = _productService.GetAll().Where(p => p.Producer == "Adidas").Select(product => new ProductIndexViewModel
            {
                Id = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                proUpdateDate = product.proUpdateDate,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender,
            }).ToList();
            return View(model);
        }
    }
}
