using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL;
using ProductManagement.Models;
using System.Text.Json;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManagementService _productManagementService;

        public ProductController (ProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }


        //views methods
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _productManagementService.FetchAsync();
            await Task.Delay(1000);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productManagementService.GetProductByIdAsync(id);
            if (product == null)
            {
                return View("Error");
            }
            return View(product);
        }
    }
}
