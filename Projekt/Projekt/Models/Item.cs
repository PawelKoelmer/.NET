using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Validation;

namespace Projekt.Models
{
    public class Item
    {

       public int ItemId { get; set; }
       public int ItemCategoryId { get; set; }
       public DateTime addTime { get; set; }
       [ProductNameValidation]
       public string productName { get; set; }
       [ProductPriceValidation]
       public decimal productPrice { get; set; }
       public string productDescription { get; set; }
       public bool avaiablity { get; set; }


        public virtual ItemCategory ItemCategory { get; set; }


    }
}