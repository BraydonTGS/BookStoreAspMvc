using BookStoreWeb.Interfaces;
using BookStoreWeb.Models;
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

        // Get //
        public IActionResult Create()
        {
            return View();
        }

        // Post //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the Name."); 
            }
            if(ModelState.IsValid)
            {
                _repository.CreateCategory(obj);
                return RedirectToAction("Index");
            }
            return View(obj);   
        }
    }
}
