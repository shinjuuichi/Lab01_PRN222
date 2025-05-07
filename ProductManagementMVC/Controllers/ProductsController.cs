using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessObjects;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _contextProduct;
        private readonly ICategoryService _contextCategory;

        public ProductsController(IProductService contextProduct, ICategoryService contextCategory)
        {
            _contextProduct = contextProduct;
            _contextCategory = contextCategory;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var myStoreContext = _contextProduct.GetProducts();
            return View(myStoreContext.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _contextProduct.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            _contextProduct.SaveProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _contextProduct.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            try
            {
                _contextProduct.UpdateProduct(product);
            }
            catch (Exception)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _contextProduct.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _contextProduct.GetProductById(id);
            if (product != null)
            {
                _contextProduct.DeleteProduct(product);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            var tmp = _contextProduct.GetProductById(id);
            return (tmp != null) ? true : false;
        }
    }
}
