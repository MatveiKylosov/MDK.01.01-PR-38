using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategories : ICategories
    {
        public IEnumerable<Categories> AllCategories
        { 
            get
            {
                return new List<Categories>() {
                    new Categories()
                    {
                      Id = 0,
                      Name = "Name0",
                      Description = "Description0"
                    },
                    new Categories()
                    {
                      Id = 1,
                      Name = "Name1",
                      Description = "Description1"
                    },
                    new Categories()
                    {
                      Id = 2,
                      Name = "Name2",
                      Description = "Description2"
                    },
                    new Categories()
                    {
                      Id = 3,
                      Name = "Name3",
                      Description = "Description3"
                    },
                    new Categories()
                    {
                      Id = 4,
                      Name = "Name4",
                      Description = "Description4"
                    },
                };
            } 
        }
    }
}
