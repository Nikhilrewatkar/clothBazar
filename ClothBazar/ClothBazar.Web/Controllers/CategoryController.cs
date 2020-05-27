using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {

        CategoriesService categoryService = new CategoriesService();
        // GET: GetCategorys
        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.getCategories();
            return View(categories);
        }

        // GET: GetCategory/Id
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var category = categoryService.getCategory(Id);
            return View(category);
        }


        // GET: CreateCategory
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: CreateCategory
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.saveCategory(category);
            return RedirectToAction("Index");
        }


        // GET: EditCategory/Id
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var category = categoryService.getCategory(Id);
            return View(category);
        }

        //POST: EditCategory
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.updateCategory(category);
            return RedirectToAction("Index");
        }

        // GET: DeleteCategory/Id
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var category = categoryService.getCategory(Id);
            return View(category);
        }

        //POST: DeleteCategory
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            category = categoryService.getCategory(category.Id);
            categoryService.deleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}