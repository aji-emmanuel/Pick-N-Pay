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
            Category productCategory = new Category
            {
                CategoryName = categoryName
            };
            return View(productCategory);
        }

        public IActionResult Details(int product)
        {
           // var product = _productRepository.GetProductById(id);
            if (product == 0)
                return NotFound();
            return View(product);
        }
    }
}
