using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
    public class WelcomeController : Controller
    {
		private readonly IProductService _productService;
        public WelcomeController(IProductService productService)
        {
            _productService = productService;
        }
		public IActionResult Index()
        {
			var model = new ProductViewModel();
			model.Products = _productService.GetList();
			return View(model);
        }
        
    }
}
