using System.Threading.Tasks;
using Week8PicknPay.Database;

namespace Week8PicknPay.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IAddressRepository _addresses;
        private IProductRepository _products;
        private IOrderRepository _orders;
        private ICategoryRepository _categories;
        private IShoppingCart _shoppingCart;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAddressRepository Addresses => _addresses ??= new AddressRepository(_context);
        public IProductRepository Products => _products ??= new ProductRepository(_context);
        public IOrderRepository Orders => _orders ??= new OrderRepository(_context);
        public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
        public IShoppingCart ShoppingCart => _shoppingCart ??= new ShoppingCart(_context);

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
