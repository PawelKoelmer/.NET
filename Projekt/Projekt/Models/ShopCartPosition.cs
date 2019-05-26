using Projekt.Models;

namespace Projekt.Models
{
    public class ShopCartPosition
    {
        public int ShopCartPositionId { get; set; }
        public Item Item { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
    }
}