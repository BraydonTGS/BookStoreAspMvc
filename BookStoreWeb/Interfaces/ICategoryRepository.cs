using BookStoreWeb.Models;

namespace BookStoreWeb.Interfaces
{
    public interface ICategoryRepository
    {

        public IEnumerable<Category> GetCategories();
        public void CreateCategory(Category category);

        public Category GetUpdateCategory(int id);

        public void UpdateCategory(Category category); 
    }
}
