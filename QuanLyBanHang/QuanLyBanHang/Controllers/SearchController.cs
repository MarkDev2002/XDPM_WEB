using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyBanHang.Service;

namespace QuanLyBanHang.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IProductService _productService;
        public SearchController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductSearch(string proName)
        {
            var products = _productService.GetAll().Where(p => p.proName.ToUpper().Contains(proName.ToUpper())).ToList();
            return View(products);
        }
    }
}
