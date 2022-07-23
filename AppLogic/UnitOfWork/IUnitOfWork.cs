using System.Threading.Tasks;

namespace Week8PicknPay.Repository
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IShoppingCart ShoppingCart { get; }

        Task<bool> SaveChanges();
    }
}