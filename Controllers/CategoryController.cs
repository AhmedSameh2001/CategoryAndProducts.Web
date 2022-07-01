using CategoryAndProducts.Web.Data;
using CategoryAndProducts.Web.Models;
using CategoryAndProducts.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CategoryAndProducts.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult index()
        {
            var categoriesList = _db.categories.Where(x => !x.isDelete).ToList();
            return View(categoriesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel input)
        {
            if (ModelState.IsValid)
            {
                var category = new Category();
                category.Name = input.Name;
                category.CreatedAt = DateTime.Now;
                category.UpdateBy = input.Name;
                _db.categories.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _db.categories.SingleOrDefault(x => x.ID == id && !x.isDelete);
            if (category == null)
                return NotFound();

            var vm = new UpdateCategoryViewModel();
            vm.ID = category.ID;
            vm.Name = category.Name;
            
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel input)
        {
            if (ModelState.IsValid)
            {
                var category = _db.categories.SingleOrDefault(x => x.ID == input.ID && !x.isDelete);
                if (category == null)
                    return NotFound();

                category.Name = input.Name;
                _db.categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _db.categories.SingleOrDefault(x => x.ID == id && !x.isDelete);
            if (category == null)
                return NotFound();

            category.isDelete = true;
            _db.categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
