using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICategories
    {
        public IEnumerable<Models.Categories> AllCategories { get; }
        public int Add(Models.Categories category);
        public int Update(Models.Categories category);
        public void Delete(Models.Categories category);
    }
}
