using Projekt.Models;

namespace Projekt.Infrastructure
{
    public class ShopCartPosition
    {
        public Item Item { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
    }
}