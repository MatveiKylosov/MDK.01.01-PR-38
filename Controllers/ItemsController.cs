using Shop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.ViewModell;
using System.Collections.Generic;
using System.Collections;
using Shop.Data.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;


namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategories;
        private VMItems VMItems = new VMItems();

        private readonly IHostingEnvironment HostingEnvironment;
        public ItemsController(IItems IAllItems, ICategories IAllCategories, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
            this.HostingEnvironment = environment;
        }

        public ViewResult List(int id = 0, string sortOrder = "asc", string search = "")
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.FindItems(search);
            
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            VMItems.SortOrder = sortOrder;
            return View(VMItems);
        }


        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> categories = IAllCategories.AllCategories;
            return View(categories);
        }

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if(files != null) {
                var uploads = Path.Combine(HostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int id = IAllItems.Add(newItems);

            return Redirect("/Items/Update?id=" + id);
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            ViewBag.Title = "Test";
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.Items = IAllItems.AllItems.Where(x => x.Id == id);
            VMItems.SelectCategory = VMItems.Items.FirstOrDefault().Category.Id;

            return View(VMItems);
        }
        [HttpPost]
        public RedirectResult Update(int id, string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(HostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Id = id;
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int idTake = IAllItems.Update(newItems);

            return Redirect("/Items/Update?id=" + id);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            ViewBag.Title = "Test";
            VMItems.Items = IAllItems.AllItems.Where(x => x.Id == id);
            IAllItems.Delete(VMItems.Items.FirstOrDefault());
            return View(VMItems);
        }
    }

}
