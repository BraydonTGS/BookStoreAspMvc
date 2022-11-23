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

        // Get //
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

        // Get //
        public IActionResult UpdateCategory(int id)
        {
            if (id == 0) 
            {
                return NotFound(); 
            }

            var category = _repository.GetUpdateCategory(id);

            if (category == null)
            {
                return NotFound(); 
            }
            return View(category);

        }

        // Update //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the Name.");
            }
            if (ModelState.IsValid)
            {
                _repository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
