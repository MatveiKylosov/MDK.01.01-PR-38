using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICategories
    {
        public IEnumerable<Models.Categories> AllCategories { get; }
    }
}
