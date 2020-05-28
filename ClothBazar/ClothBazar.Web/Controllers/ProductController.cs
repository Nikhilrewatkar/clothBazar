using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductServices productService = new ProductServices();
        // GET: GetProducts
        [HttpGet]
        public ActionResult Index()
        {
            var products = productService.getProducts();
            return View(products);
        }

        // GET: GetProduct/Id
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var category = productService.getProduct(Id);
            return View(category);
        }


        // GET: CreateProduct
        [HttpGet]
        public ActionResult Create()
        {
            CategoriesService categoryService = new CategoriesService();
            var categories = categoryService.getCategories();
            return View(categories);
        }

        //POST: CreateProduct
        [HttpPost]
        public ActionResult Create(newCategoryViewModel model)
        {
            CategoriesService categoryService = new CategoriesService();
          
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Price = model.Price;
            newProduct.Description = model.Description;
            newProduct.Category = categoryService.getCategory(model.CategoryId);

            productService.saveProduct(newProduct);

            return RedirectToAction("Index");
        }


        // GET: EditCategory/Id
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = productService.getProduct(Id);
            return View(product);
        }

        //POST: EditCategory
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.updateProduct(product);
            return RedirectToAction("Index");
        }

        // GET: DeleteCategory/Id
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var product = productService.getProduct(Id);
            return View(product);
        }

        //POST: DeleteCategory
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            product = productService.getProduct(product.Id);
            productService.deleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}