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
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Returns a view of Top deal products
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                TopDealProducts = _productRepository.TopDealProducts
            };

            return View(homeViewModel);
        }
    }
}
