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
        public IEnumerable<Product> GetAllProducts(string categoryName)
        {
            if(categoryName != "All")
            {
                Category category = _appDbContext.Categories.FirstOrDefault(category => category.CategoryName == categoryName);
                return _appDbContext.Products.Where(prod => prod.CategoryId == category.CategoryId);
            }
            return _appDbContext.Products.ToList();
        }

        /// <summary>
        /// Returns products whose IsTopDeal property is set to true.
        /// </summary>
        public IEnumerable<Product> TopDealProducts
        {
            get => _appDbContext.Products.Where(p => p.IsTopDeal); //.Include(c => c.Category).Where(p => p.IsTopDeal);
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

        public IEnumerable<Product> SearchProducts(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                var category = _appDbContext.Categories.FirstOrDefault(cat => cat.CategoryName.ToLower().Contains(query.ToLower().Trim()));

                if (category != null)
                {
                    return _appDbContext.Products.Where(prod => prod.CategoryId == category.CategoryId);
                }
                return _appDbContext.Products.Where(x => x.Name.ToLower().Contains(query.ToLower().Trim()));
            }
            return default;
        }
    }
}
