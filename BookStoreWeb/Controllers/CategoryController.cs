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

        // Get All //
        public IActionResult Index()
        {
            var categories = _repository.GetCategories(); 
            return View(categories);
        }

        // Get Post //
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
                // Only stays in data for one redirect //
                TempData["success"] = "Category Created Successfully"; 
                return RedirectToAction("Index");
            }
            return View(obj);   
        }

        // Get Update //
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
                TempData["success"] = "Category Succesfully Updated"; 
                return RedirectToAction("Index");
            }
            return View(category);
        }


        // Get Delete//
        public IActionResult DeleteCategory(int id)
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

        // Delete //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(Category category)
        {
                _repository.DeleteCategory(category);
              TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
        }
    }
}
