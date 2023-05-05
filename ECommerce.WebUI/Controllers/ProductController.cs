using App.Business.Abstract;
using App.Business.Enum;
using App.Entities.Models;
using ECommerce.WebUI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Printing;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;


        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public static CheckFilter FilterState { get; set; } = CheckFilter.Zero;


        public IActionResult Index(int page = 1, int category = 0, CheckFilter filterAZ = CheckFilter.Zero, CheckFilter filter1_100 = CheckFilter.Zero)
        {
            int pageSize = 10;
            var products = _productService.GetAllByCategory(category);
            if (filterAZ != CheckFilter.Zero)
            {
                products = _productService.GetAllByFilterAZ(products, filterAZ);
                //if(filterAZ==CheckFilter.One) FilterState = CheckFilter.One;
                //else FilterState = CheckFilter.Two;
            }
            //else FilterState = filterAZ;
            if (filter1_100 != CheckFilter.Zero)
            {
                products = _productService.GetAllByFilterPrice(products, filter1_100);
            }
            

            var model = new ProductListViewModel
            {
                AZSort = filterAZ,
                PriceSort = filter1_100,
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel();
            model.Product = new Product();
            model.Categories=_categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ProductAddViewModel model)
        {
            _productService.Add(model.Product);
            return RedirectToAction("index");
        }
    }
}
