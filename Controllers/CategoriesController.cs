using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.IO;
using System;
using Shop.Data.ViewModell;
using System.Linq;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategories IAllCategories;
        private VMItems VMItems = new VMItems();
        public CategoriesController(ICategories IAllCategories) => this.IAllCategories = IAllCategories;
        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";

            var cars = IAllCategories.AllCategories;
            return View(cars);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(string name, string description)
        {
            Categories newCategories = new Categories();
            newCategories.Name = name;
            newCategories.Description = description;

            int id = IAllCategories.Add(newCategories);

            return Redirect("/Categories/Update?id=" + id);
        }


        [HttpGet]
        public ViewResult Update(int id)
        {
            VMItems.SelectCategory = id;
            VMItems.Categories = IAllCategories.AllCategories;
            ViewBag.Title = $"Изменение категории {VMItems.Categories.FirstOrDefault(x => x.Id == id).Name}";
            return View(VMItems);
        }
        [HttpPost]
        public RedirectResult Update(int id, string name, string description)
        {

            Categories newCategories = new Categories();
            newCategories.Id = id;
            newCategories.Name = name;
            newCategories.Description = description;

            int Id = IAllCategories.Update(newCategories);

            return Redirect("/Categories/Update?id=" + Id);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            ViewBag.Title = "Удаление";
            VMItems.Categories = IAllCategories.AllCategories.Where(x => x.Id == id);
            IAllCategories.Delete(VMItems.Categories.FirstOrDefault());
            return View(VMItems);
        }
    }
}
