using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

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

 
        public ViewResult List(int? categoryId)
        {
           // IEnumerable<Product> products;
            Category productCategory = new Category();

            if (categoryId == null)
            {
              //  products = _productRepository.GetAllProducts();
                productCategory.CategoryName = "All products";
            }
            else
            {
                productCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryId);
               // products = _productRepository.GetCategoryProducts(productCategory.CategoryId);
            }

            return View(productCategory);

            //return View(new ProductsListViewModel
            //{
            //    Products = products,
            //    CurrentCategory = productCategory
            //});
        }

       
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
