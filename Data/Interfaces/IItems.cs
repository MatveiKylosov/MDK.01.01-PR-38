﻿using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Models.Items> AllItems { get; }
        public IEnumerable<Items> FindItems(string search);
        public int Add(Models.Items item);
        public int Update(Models.Items item);
    }
}
