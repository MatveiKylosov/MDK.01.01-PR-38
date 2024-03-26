using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategories _category = new MockCategories();
        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>() {
                    new Items()
                    {
                        Id = 0,
                        Name = "Name1",
                        Description = "Description1",
                        Img = @"https://www.nicepng.com/png/detail/32-325232_teardrop-falling-on-sad-emoticon-face-comments-happy.png",
                        Price = 100,
                        Category = _category.AllCategories.Where(x => x.Id == 0).FirstOrDefault()
                    },
                    new Items()
                    {
                        Id = 1,
                        Name = "Name2",
                        Description = "Description2",
                        Img = @"https://www.nicepng.com/png/detail/32-325232_teardrop-falling-on-sad-emoticon-face-comments-happy.png",
                        Price = 101,
                        Category = _category.AllCategories.Where(x => x.Id == 1).FirstOrDefault()
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Name2",
                        Description = "Description2",
                        Img = @"https://www.nicepng.com/png/detail/32-325232_teardrop-falling-on-sad-emoticon-face-comments-happy.png",
                        Price = 102,
                        Category = _category.AllCategories.Where(x => x.Id == 2).FirstOrDefault()
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "Name3",
                        Description = "Description3",
                        Img = @"https://www.nicepng.com/png/detail/32-325232_teardrop-falling-on-sad-emoticon-face-comments-happy.png",
                        Price = 103,
                        Category = _category.AllCategories.Where(x => x.Id == 3).FirstOrDefault()
                    },
                    new Items()
                    {
                        Id = 4,
                        Name = "Name4",
                        Description = "Description4",
                        Img = @"https://www.nicepng.com/png/detail/32-325232_teardrop-falling-on-sad-emoticon-face-comments-happy.png",
                        Price = 104,
                        Category = _category.AllCategories.Where(x => x.Id == 4).FirstOrDefault()
                    }
                };
            }
        }
    }
}
