using MarketApp.Domain.Configurations;
using MarketApp.Domain.Entities;
using MarketApp.Models;
using MarketApp.Service.DTOs;
using MarketApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Index(string searchString, int? pageIndex)
        {
            var @params = new PaginationParams()
            {
                PageIndex = pageIndex ?? 1,
                PageSize = 10,
            };

            PaginationMetaData<Product> products = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                products = await this.productService.GetAllAsync(@params,
                    product => product.ItemName.Contains(searchString));
            }

            products = await this.productService.GetAllAsync(@params);

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Create([Bind("ItemName,Quantity,Price")] ProductForCreationDto productDto)
        {
            if (ModelState.IsValid)
            {
                await this.productService.AddAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        public async ValueTask<IActionResult> Edit(long id)
        {
            var product = await this.productService.GetAsync(u => u.Id.Equals(id));

            return View(product);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Edit(long id, ProductForCreationDto productDto)
        {
            var product = await this.productService.UpdateAsync(id, productDto);

            return View(product);
        }

        public async ValueTask<IActionResult> Delete(long? id)
        {
            if (id is null)
                return NotFound();

            var product = await this.productService.GetAsync(u => u.Id.Equals(id));
            if (product is null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> DeleteComfirmed(long? id)
        {
            if (id is null)
                return NotFound();

            await this.productService.DeleteAsync(product => product.Id.Equals(id));

            return RedirectToAction(nameof(Index));
        }

        public async ValueTask<IActionResult> Details(long id)
        {
            var product = await this.productService.GetAsync(product => product.Id.Equals(id));

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}