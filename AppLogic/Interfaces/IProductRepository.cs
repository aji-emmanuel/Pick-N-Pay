using System.Collections.Generic;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(int? categoryId);
        IEnumerable<Product> TopDealProducts { get; }
        Product GetProductById(int productId);
    }
}
