using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> TopDealProducts { get; }
        Product GetProductById(int productId);
    }
}
