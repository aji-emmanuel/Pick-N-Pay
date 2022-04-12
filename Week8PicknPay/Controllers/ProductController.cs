using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Week8PicknPay.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week8PicknPay.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

       
        /// <summary>
        /// Creates a list of all the products or a selected product using category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public ViewResult List(int? categoryId)
        {
            IEnumerable<Product> products;
            Category productCategory = new Category();

            if (categoryId == null)
            {
                products = _productRepository.GetAllProducts(categoryId);
                productCategory.CategoryName = "All products";
            }
            else
            {
                productCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryId);
                products = _productRepository.GetCategoryProducts(productCategory.CategoryId);
            }

            return View(new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = productCategory
            });
        }

        /// <summary>
        /// Gets a specific product using product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
