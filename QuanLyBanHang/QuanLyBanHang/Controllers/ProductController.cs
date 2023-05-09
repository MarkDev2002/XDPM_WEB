using System.Data;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Models.Product;
using QuanLyBanHang.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLyBanHang.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll().Select(product => new ProductIndexViewModel
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
        public IActionResult Detail(int id)
        {
            var product=_productService.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            var model=new ProductDetailViewModel
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
        public IActionResult Create()
        {
            var model = new ProductCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    proID = model.Id,
                    proName = model.proName,
                    proSize = model.proSize,
                    proPrice = model.proPrice,
                    proDiscount = model.proDiscount,
                    proUpdateDate = model.proUpdateDate,
                    proDescription = model.proDescription,
                    Producer = model.Producer,
                    Rate = model.Rate,
                    proStatus = model.proStatus,
                    forGender = model.forGender
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"picture/products";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    product.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _productService.CreateAsSync(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDeleteViewModel
            {
                Id = product.proID,
                ImageUrl = product.ImageUrl,
                proName = product.proName,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductDeleteViewModel model)
        {
            var product = _productService.GetById(model.Id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteById(model.Id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductEditViewModel
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
                proStatus = product.proStatus,
                forGender = product.forGender
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(model.Id);

                product.proID = model.Id;
                product.proName = model.proName;
                product.proSize = model.proSize;
                product.proPrice = model.proPrice;
                product.proDiscount = model.proDiscount;
                product.proUpdateDate = model.proUpdateDate;
                product.proDescription = model.proDescription;
                product.Producer = model.Producer;
                product.Rate = model.Rate;
                product.proStatus = model.proStatus;
                product.forGender = model.forGender;

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"picture/products";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webrootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    product.ImageUrl = "/" + uploadDir + "/" + fileName;
                };
                await _productService.UpdateAsSync(product);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
