﻿using System;
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
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Gets and returns a view of shopping cart items
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        /// <summary>
        /// Adds a product to the shopping cart
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Removes a product from the shopping cart
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
