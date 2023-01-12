using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Models;
using WebCoreApp.Services;

namespace WebCoreApp.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly ILogger<CategoryService> _logger;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            //_logger.Log(LogLevel.Information, "Lay danh sach category");
            var model = new CategoryViewModel();
            model.Responses=_categoryService.GetList();
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            var rs = _categoryService.Insert(model.CategoryResponse);
            if(string.IsNullOrEmpty(rs))
            return RedirectToAction("Index");
            else
            {
                ViewBag.Message = rs;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new CategoryViewModel();
            model.CategoryResponse = _categoryService.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CategoryViewModel model)
        {
            //_logger.Log(LogLevel.Warning, "Delete category id : " + model.CategoryResponse.Id);
            _categoryService.Delete(model.CategoryResponse.Id);
            var rs=_categoryService.GetList();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new CategoryViewModel();
            model.CategoryResponse= _categoryService.Get(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            var rs=_categoryService.Update(model.CategoryResponse);
            if(string.IsNullOrEmpty(rs))
            return RedirectToAction("Index");
            else
            {
                model.CategoryResponse = _categoryService.Get(model.CategoryResponse.Id);
                ViewBag.Message = rs;
                return View(model);
            }
        }
    }
}
