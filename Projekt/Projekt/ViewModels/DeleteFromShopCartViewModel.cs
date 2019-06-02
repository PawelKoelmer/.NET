using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class DeleteFromShopCartViewModel
    {
        public decimal shopCartPrice { get; set; }
        public int shopCartPositionsQuantity { get; set; }
        public int shopCartDeletingPositionQuantity { get; set; }
        public int DeletePositionId { get; set; }
    }
}