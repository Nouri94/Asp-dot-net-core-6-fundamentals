namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext _dbContext;

        public CategoryRepository(PieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories
        {
            get { return _dbContext.Categories.OrderBy(c=>c.CategoryName); }
        }
    }
}
