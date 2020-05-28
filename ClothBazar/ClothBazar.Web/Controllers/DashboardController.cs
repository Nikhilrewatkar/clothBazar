using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class DashboardController : Controller
    {

        CategoriesService categoryService = new CategoriesService();
        // GET: Dashboard
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.Categories = categoryService.getCategories();
            return View(model);
        }
    }
}