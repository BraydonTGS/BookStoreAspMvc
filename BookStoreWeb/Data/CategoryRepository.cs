using BookStoreWeb.Interfaces;
using BookStoreWeb.Models;

namespace BookStoreWeb.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList(); 
        }
    }
}
