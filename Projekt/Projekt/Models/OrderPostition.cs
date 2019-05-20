namespace Projekt.Models
{
    public class OrderPostition
    {
       public int OrderPostitionId {get;set;}
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal orderPrice { get; set; }
        public virtual Item item { get; set; }
        public virtual Order order { get; set; }
    }
}