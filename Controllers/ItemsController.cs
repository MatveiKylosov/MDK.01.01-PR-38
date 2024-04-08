using Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.ViewModell;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategories;
        private VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategories IAllCategories)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
        }

        public ViewResult List(int id = 0, string sortOrder = "asc")
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            VMItems.SortOrder = sortOrder;
            return View(VMItems);
        }
    }
}
