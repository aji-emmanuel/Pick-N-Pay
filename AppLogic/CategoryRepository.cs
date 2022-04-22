using System.Collections.Generic;
using System.Linq;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Gets a list of all categories from the database
        /// </summary>
        public IEnumerable<Category> AllCategories => _appDbContext.Categories;

        public IEnumerable<string> CategoryNames => _appDbContext.Categories.Select(x => x.CategoryName).OrderBy(x => x);
    }
}
