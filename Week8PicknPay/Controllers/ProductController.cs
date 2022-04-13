using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Controllers
{
    public class ProductController : Controller
    {
        //private readonly IProductRepository _productRepository;
        //private readonly ICategoryRepository _categoryRepository;

        //public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        //{
        //    _productRepository = productRepository;
        //    _categoryRepository = categoryRepository;
        //}

 
        public ViewResult List(string categoryName)
        {
            // IEnumerable<Product> products;
            Category productCategory = new Category
            {

                //if (String.IsNullOrWhiteSpace(categoryName))
                //{
                //  //  products = _productRepository.GetAllProducts();
                //    productCategory.CategoryName = "All products";
                //}
                //else
                //{
                CategoryName = categoryName
            };
            // products = _productRepository.GetCategoryProducts(productCategory.CategoryId);
            // }

            return View(productCategory);

            //return View(new ProductsListViewModel
            //{
            //    Products = products,
            //    CurrentCategory = productCategory
            //});
        }

       
        public IActionResult Details(Product product)
        {
           // var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
