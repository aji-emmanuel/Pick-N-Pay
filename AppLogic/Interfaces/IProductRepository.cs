using System.Collections.Generic;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(string categoryName);
        IEnumerable<Product> SearchProducts(string query);
        IEnumerable<Product> TopDealProducts { get; }
        Product GetProductById(int productId);
    }
}
