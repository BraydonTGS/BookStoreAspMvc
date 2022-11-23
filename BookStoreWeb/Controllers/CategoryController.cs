using BookStoreWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var categories = _repository.GetCategories(); 
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
