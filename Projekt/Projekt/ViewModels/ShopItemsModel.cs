using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class ShopItemsModel
    {
        public IEnumerable<ItemCategory> ItemsCategories { get; set; }
        public IEnumerable<Item> ItemList { get; set; }
    }
}