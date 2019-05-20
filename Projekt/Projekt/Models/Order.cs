using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string buyerName { get; set; }
        public string buyerLastName { get; set; }
        public string buyerEmail { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string homeFlatNumber { get; set; }
        public string zipCode { get; set; }
        public string telNumber {get;set;}
        public DateTime addTime { get; set; }
        public shipmentStatus shipmentStatus { get; set; }

        List<OrderPostition> OrderPosition { get; set; }

    }

    public enum shipmentStatus
    {
        New,
        Realized
    }
}