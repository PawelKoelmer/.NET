using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class EditItemViewModel
    {
        public Item Item { get; set; }
        public IEnumerable<ItemCategory> categories { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}