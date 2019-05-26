using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class ShopCartViewModel
    {

        public List<ShopCartPosition> shopCartPosition {get;set;}
        public decimal priceOfProducts { get; set; }

    }
}