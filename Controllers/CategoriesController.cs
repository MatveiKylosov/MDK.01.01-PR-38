using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategories IAllCategories;
        public CategoriesController(ICategories IAllCategories) => this.IAllCategories = IAllCategories;
        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";

            var cars = IAllCategories.AllCategories;
            return View(cars);
        }
    }
}
