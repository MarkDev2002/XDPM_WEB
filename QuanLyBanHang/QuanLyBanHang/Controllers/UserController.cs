using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Models.User;
using Microsoft.AspNetCore.Authorization;
using QuanLyBanHang.Models.Product;
using QuanLyBanHang.Service;
using QuanLyBanHang.Service.implementation;

namespace QuanLyBanHang.Controllers
{
    public class UserController : Controller
    {
        private ICustomerService _customerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public UserController(
            ICustomerService customerService,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegisterViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                { 
                    UserName = model.UserName, 
                    Email = model.cusEmail 
                };                
                var result = await _userManager.CreateAsync(user, model.passWord);
                if (result.Succeeded)
                {
                    var customer = new Customer
                    {
                        nameofUser = model.UserName,
                        cusPhone = model.cusPhone,
                        cusFullName = model.cusFullName,
                        cusEmail = model.cusEmail,
                        cusGender = model.Gender,
                    };
                    await _customerService.CreateAsSync(customer);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {               
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.passWord, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
            return View(model);
        }
    }
}
