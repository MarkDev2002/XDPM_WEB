﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Models.Cart;
using QuanLyBanHang.Models.Order;
using QuanLyBanHang.Models.Product;
using QuanLyBanHang.Service;

namespace QuanLyBanHang.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private ICartService _cartService;
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public CartController(IProductService productService,
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
            var username = _userManager.GetUserName(User);
            var model = _cartService.GetAll().Where(c => c.nameofUser == username).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            if(product.proStatus == Status.Unavailable)
            {
                TempData["ErrorMessage"] = "["+product.proName+"] is unavailable.";
                return RedirectToAction("Index","Shop");
            }
            var model = new CartAddViewModel
            {
                
                proID = product.proID,
                proName = product.proName,
                proSize = product.proSize,
                proPrice = product.proPrice,
                Producer = product.Producer,
                ImageUrl = product.ImageUrl,
                forGender = product.forGender,
                availableQuantity = product.Quantity
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromForm] CartAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = _userManager.GetUserName(User);                
                if (username == null)
                {
                    return NotFound();
                }
                var findCartItem = _cartService.GetAll().Where(c => c.proId == model.proID && c.nameofUser == username).FirstOrDefault();
                var temp = 0;
                if (findCartItem == null)
                {
                    temp = 0;
                }
                else
                    temp = findCartItem.Quantity;
                if (model.Quantity + temp <= model.availableQuantity)
                {
                    var cart = new Cart
                    {
                        proPrice = model.proPrice,
                        nameofUser = username,
                        proId = model.proID,
                        proName = model.proName,
                        proImage = model.ImageUrl,
                        Quantity = model.Quantity,
                        DateCreated = model.DateCreated,
                    };
                    await _cartService.AddItemToCart(cart);
                    return RedirectToAction("Index", "Shop");
                }
                else
                {
                    TempData["ErrorMessage"] = "Available quantity is: " + model.availableQuantity + ", please try again!";
                    return View(model);
                }
            }
            return View();

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
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
                proStatus = product.proStatus,
                forGender = product.forGender
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult ReduceQuantity(int id)
        {
            var cart = _cartService.GetByProID(id);
            if (cart == null)
            {
                return NotFound();
            }
            var model = new CartDeleteViewModel
            {
                UserName = cart.nameofUser,
                proId = cart.proId,
                proImage = cart.proImage,
                proName = cart.proName,
                Quantity = cart.Quantity
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReduceQuantity(CartDeleteViewModel model)
        {
            var cartItem = _cartService.GetByProID(model.proId);
            if (cartItem == null)
            {
                return NotFound();
            }
            if (cartItem.Quantity <= model.Quantity)
            {
                await _cartService.DeleteById(model.UserName);
                return RedirectToAction("Index");
            }
            else
            {
                var cart = _cartService.GetByUserName(model.UserName);
                cart.Quantity -= model.Quantity;
                await _cartService.UpdateAsSync(cart);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cart = _cartService.GetByProID(id);
            if (cart == null)
            {
                return NotFound();
            }
            var model = new CartDeleteViewModel
            {
                proId = cart.proId,
                proImage = cart.proImage,
                proName = cart.proName,
                Quantity = cart.Quantity,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CartDeleteViewModel model)
        {
            var cartItem = _cartService.GetByProID(model.proId);
            if (cartItem == null)
            {
                return NotFound();
            }
            await _cartService.DeleteByProId(model.proId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteAllYourCart(string id)
        {
            var cart = _cartService.GetByUserName(id);
            if (cart == null)
            {
                return RedirectToAction("Index");
            }
            var model = new CartDeleteViewModel
            {
                UserName = cart.nameofUser
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAllYourCart()
        {
            await _cartService.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            var model = new OrderCreateViewModel();           
            model.orderStatus = OrderStatus.InProgress;
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder([FromForm]OrderCreateViewModel model)
        {
            var username = _userManager.GetUserName(User);
            var cart = _cartService.GetAll().ToList();
            if (username == null)
            {
                return NotFound();
            }
            foreach (Cart od in cart)
            {
                var product = _productService.GetById(od.proId);
                if (product.Quantity < od.Quantity)
                {
                    TempData["ErrorMessage"] = "[" + product.proName + "] quantity is not enough. Available quantity is: " + product.Quantity + ".";
                    return View();
                }
            }
            var order = new Order
            {
                UserName = username,
                orderTotal = 0,
                orderID = model.orderID,
                cusPhone = model.cusPhone,
                orderMessage = model.orderMessage,
                orderDateTime = model.orderDateTime,
                orderStatus = model.orderStatus,
                cusAddress = model.cusAddress,
                paymentMethod = model.paymentMethod,
            };
            var checkEmptyCart = _cartService.GetByUserName(username);
            if (checkEmptyCart == null)
            {
                return RedirectToAction("Order","Shop");
            }
            
            await _orderService.CreateAsSync(order);
            foreach (Cart od in cart) 
            {
                var orderDetail =new OrderDetail
                {
                    proID = od.proId,
                    orderID = order.orderID,
                    ordtsItemPrice = od.proPrice,
                    ordtsQuantity = od.Quantity,
                    ordtsTotal = od.Quantity * od.proPrice,
                };
                var product = _productService.GetById(orderDetail.proID);
                product.Quantity -= orderDetail.ordtsQuantity;
                if (product.Quantity == 0)
                {
                    product.proStatus = Status.Unavailable;
                }
                await _productService.UpdateAsSync(product);
                await _orderDetailService.CreateAsSync(orderDetail);                
            } 
            var orderTotal = (long)_orderDetailService.GetTotalOrder(order.orderID);
            var updateOrder = _orderService.GetById(order.orderID);
            updateOrder.orderTotal = orderTotal;
            await _orderService.UpdateAsSync(updateOrder);               
            await _cartService.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Order()
        {
            var username = _userManager.GetUserName(User);
            var model = _orderService.GetAll().Where(c => c.UserName == username).ToList();
            return View(model);
        }
    }
}
