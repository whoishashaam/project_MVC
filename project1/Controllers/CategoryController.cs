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
            if (ModelState.IsValid) {  //check if the model is valid or not (if the data is in the correct format or not
            _db.Categories.Add(obj);
            _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
            
    }
}
