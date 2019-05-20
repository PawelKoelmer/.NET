using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Item
    {

       public int ItemId { get; set; }
       public string productName { get; set; }
       public decimal productPrice { get; set; }
       public int inStock { get; set; }
       public string productDescription { get; set; }
       public decimal productScore { get; set; }
       public bool avaiablity { get; set; }

    }
}