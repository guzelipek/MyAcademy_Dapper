using DapperApp.Web.DTOs.Products;
using DapperApp.Web.Services.Categories;
using DapperApp.Web.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DapperApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService,
                                    ICategoryService _categoryService) : Controller
    {
        private async Task LoadCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = (from category in categories
                                   select new SelectListItem
                                   {
                                       Text = category.Name,
                                       Value = category.CategoryId.ToString()
                                   }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var products=await _productService.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            await _productService.CreateAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await LoadCategories();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto model)
        {
            await _productService.UpdateAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _productService.ChangeStatusAsync(id);
            return RedirectToAction("Index");
        }
    }
}
