using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        /// <returns>All products in a category or all products in database.</returns>
        public IEnumerable<Product> GetAllProducts(int? categoryId)
        {
            if(categoryId == 0)
            {
                return _appDbContext.Products.ToList();
            }
            else
            {
                return _appDbContext.Products.Where(prod => prod.CategoryId == categoryId).ToList();
            }
        }


        /// <param name="categoryId"></param>
        /// <returns>All products in a given category</returns>
        public IEnumerable<Product> GetCategoryProducts(int categoryId)
        {
            return _appDbContext.Products.Where( prod => prod.CategoryId == categoryId).ToList();
        }

        /// <summary>
        /// Returns products whose IsTopDeal property is set to true.
        /// </summary>
        public IEnumerable<Product> TopDealProducts
        {
            get
            {
                return _appDbContext.Products.Where(p => p.IsTopDeal);//.Include(c => c.Category).Where(p => p.IsTopDeal);
            }
        }

        /// <summary>
        /// Returns a particular product using the product id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
