using Microsoft.AspNetCore.Mvc;
using project1.Data;
using project1.Models;

namespace project1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly  ApplicationDbContext _db;          //configuration for Entity framework core
        public CategoryController(ApplicationDbContext db)   //configuration for Entity framework core
        {
            _db = db;                                       //configuration for Entity framework core
        }                                                  //configuration for Entity framework core
        public IActionResult Index()
        {
            List<Category> CategoryList =_db.Categories.ToList();
            return View(CategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category Name and Display Order can not be same");
            }
            if (ModelState.IsValid) {  //check if the model is valid or not (if the data is in the correct format or not
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {  //check if the model is valid or not (if the data is in the correct format or not
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }  
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
