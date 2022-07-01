using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CategoryAndProducts.Web.Data;
using CategoryAndProducts.Web.Models;
using CategoryAndProducts.Web.Services;
using CategoryAndProducts.Web.ViewModel;

namespace CategoryAndProducts.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private IFileService _fileService;
        public ProductController(ApplicationDbContext db , IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public IActionResult index()
        {                                
            var produstsLis = _db.Products.Include(c => c.Category).Where(x => !x.isDelete)
                .OrderByDescending(x => x.CreatedAt).ToList();
            return View(produstsLis);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["categoryList"] = new SelectList(_db.categories.Where(x => !x.isDelete).ToList()
                ,"ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel input)
        {
            if (ModelState.IsValid)
            {
                var nameExist = _db.Products.Any(x => x.Name == input.Name && !x.isDelete);
                if (nameExist)
                {
                    TempData["msg"] = "Product Name is Exist !!";
                    ViewData["categoryList"] = new SelectList(_db.categories.Where(x => !x.isDelete).ToList(), "ID", "Name");
                    return View(input);
                }
                var product = new Product();
                product.Name = input.Name;
                product.Description = input.Description;
                product.Price = input.Price;
                if (input.ImageUrl != null)
                {                                          
                    product.ImageUrl = await _fileService.SaveFile(input.ImageUrl,"images");
                }
                product.CategoryID = Int32.Parse(input.CategoryID);
                product.CreatedAt = DateTime.Now;
                product.UpdateBy = input.Name;
                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["msg"] = "Product Added !!";
                return RedirectToAction("Index");

            }
            ViewData["categoryList"] = new SelectList(_db.categories.Where(x => !x.isDelete).ToList()
                , "ID", "Name");
            return View(input);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.ID == id && !x.isDelete);
            if (product == null)
                return NotFound();

            var vm = new UpdateProductViewModel();
            vm.ID = product.ID;
            vm.Name = product.Name;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductViewModel input)
        {
            if (ModelState.IsValid)
            {
                var product = _db.Products.SingleOrDefault(x => x.ID == input.ID && !x.isDelete);
                if (product == null)
                    return NotFound();

                product.Name = input.Name;
                product.Price = input.Price;

                _db.Products.Update(product);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.ID == id && !x.isDelete);
            if (product == null)
                return NotFound();

            product.isDelete = true;
            _db.Products.Update(product);
            _db.SaveChanges();
            TempData["msg"] = "Item Deleted Succsfuly !!";
            return RedirectToAction("Index");
        }
    }
}
