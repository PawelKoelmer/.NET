using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string buyerName { get; set; }
        public string buyerLastName { get; set; }
        public string buyerEmail { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string homeFlatNumber { get; set; }
        public string zipCode { get; set; }
        public string telNumber {get;set;}
        public DateTime addTime { get; set; }
        public ShipmentStatus shipmentStatus { get; set; }
        public decimal orderValue { get; set; }

        public string comment { get; set; }

        public List<OrderPostition> OrderPosition { get; set; }

    }

    public enum ShipmentStatus
    {
        New,
        Realized
    }
}