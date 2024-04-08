using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Shop.Data.Models.Items> Items { get; set; }
        public IEnumerable<Shop.Data.Models.Categories> Categories { get; set; }
        public int SelectCategory = 0;
        public string SortOrder = "asc";
    }
}
