using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Returns all products contained in the database
        /// </summary>
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _appDbContext.Products.Include(c => c.Category);
            }
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
