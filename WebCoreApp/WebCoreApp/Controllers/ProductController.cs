using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment,IProductService productService,ICategoryService categoryService) {
            _productService = productService;
            _categoryService = categoryService;
            _hostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous] 
        public IActionResult Index()
        {
            TempData["error"] = "e";
            var model = new ProductViewModel();
            model.Products= _productService.GetList();
            model.Responses = _categoryService.GetList();
            return View(model);
        }
        public IActionResult Sort(int id) {
            var model = new ProductViewModel();
            model.Products = _productService.GetListByCateId(id);
            model.Responses = _categoryService.GetList();
            return PartialView("_ListProduct",model);
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (model.ProductRequest.Avatar != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path= Path.Combine(_hostEnvironment.WebRootPath, "avatar"
                    , fileName);
                var stream = System.IO.File.Create(path);
                model.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();
                model.ProductRequest.AvatarUrl = Path.Combine("avatar", fileName);
            }
            var rs = _productService.Create(model.ProductRequest);
            if (string.IsNullOrEmpty(rs))
                return RedirectToAction("Index");
            else
            {
                TempData["error"] = rs;
                ViewBag.Message = rs;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel model)
        {
            if (model.ProductRequest.Avatar != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_hostEnvironment.WebRootPath, "avatar"
                    , fileName);
                var stream = System.IO.File.Create(path);
                model.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();
                model.ProductRequest.AvatarUrl = Path.Combine("avatar", fileName);
            }
            var rs = _productService.Update(model.ProductRequest);
            if (string.IsNullOrEmpty(rs))
                return RedirectToAction("Index");
            else
            {
                TempData["error"] = rs;
                model.ProductRequest = _productService.Get(model.ProductRequest.Id);
                ViewBag.Message = rs;
                return RedirectToAction("Index", model);
            }
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel model)
        {
            //_logger.Log(LogLevel.Warning, "Delete Product id : " + model.ProductRequest.Id);
            _productService.Delete(model.ProductRequest.Id);
            
            return RedirectToAction("Index");
        }
        
    }
}
