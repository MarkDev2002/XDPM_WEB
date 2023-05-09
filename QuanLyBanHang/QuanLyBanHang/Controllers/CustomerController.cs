using System.Data;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Models.Customer;
using QuanLyBanHang.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;

namespace QuanLyBanHang.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IWebHostEnvironment _webHostEnvironment;
        public CustomerController(
            ICustomerService customerService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _customerService = customerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _customerService.GetAll().Select(customer => new CustomerIndexViewModel
            {
                UserName = customer.nameofUser,
                cusPhone = customer.cusPhone,
                cusFullName = customer.cusFullName,
                cusEmail = customer.cusEmail,
                Gender = customer.cusGender,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {

            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = new CustomerDetailViewModel
            {
                UserName = customer.nameofUser,
                cusPhone = customer.cusPhone,
                cusFullName = customer.cusFullName,
                cusEmail = customer.cusEmail,
                Gender = customer.cusGender,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
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
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var customer = _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            var model = new CustomerDeleteViewModel();
            
            model.nameOfUser = customer.nameofUser;
            model.fullName = customer.cusFullName;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CustomerDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.nameOfUser);
                if (user == null)
                {
                    return NotFound();
                }
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    var customer = _customerService.GetById(model.nameOfUser);
                    if (customer == null)
                    {
                        return NotFound();
                    }
                    await _customerService.DeleteAsync(customer);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
