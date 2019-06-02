using Projekt.Models;
using Projekt.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Infrastructure
{
    public class ShopCartManager
    {
        private ShopContext db;
        private ISessionMenager session;
        public ShopCartManager(ISessionMenager session, ShopContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<ShopCartPosition> GetShopCart()
        {
            List<ShopCartPosition> shopCart;
            if (session.Get<List<ShopCartPosition>>(Consts.ShopCartSessionKey) == null)
            {
                shopCart = new List<ShopCartPosition>();
            }
            else
            {
                shopCart = session.Get<List<ShopCartPosition>>(Consts.ShopCartSessionKey) as List<ShopCartPosition>;
            }

            return shopCart;
        }

        public void addToShopCart(int id)
        {
            var shopCart = GetShopCart();
            var shopCartPosition = shopCart.Find(k => k.Item.ItemId == id);
            if (shopCartPosition!=null)
            {
                shopCartPosition.stock += 1;
            }
            else
            {
                var itemToAdd = db.Items.Where(k => k.ItemId == id).SingleOrDefault();
                if(itemToAdd != null)
                {
                    var newPosition = new ShopCartPosition()
                    {
                        Item = itemToAdd,
                        price = itemToAdd.productPrice,
                        stock = 1
                    };
                    shopCart.Add(newPosition);
                    
                }
            }
            session.Set(Consts.ShopCartSessionKey, shopCart);
        }

        public int deleteFromShopCart(int id)
        {
            var shopCart = GetShopCart();
            var cartPosition = shopCart.Find(k => k.Item.ItemId == id);
                if(cartPosition != null)
                {
                if (cartPosition.stock > 1)
                {
                    cartPosition.stock -= 1;
                    return cartPosition.stock;
                }
                else
                {
                    shopCart.Remove(cartPosition);
                }
                }
            return 0;
        }
        public decimal getShopCartPrice()
        {
            var shopCart = GetShopCart();
            
            return shopCart.Sum(k=>(k.stock * k.price));
        }

        public int getShopCartStock()
        {
            var shopCart = GetShopCart();
            return shopCart.Sum(k => (k.stock));
        }

        public Order CreateOrder(Order newOrder,string userId)
        {
            var shopCart = GetShopCart();
            newOrder.addTime = DateTime.Now;
            newOrder.UserId = userId;
            db.Orders.Add(newOrder);
            if (newOrder.OrderPosition == null)
            {
                newOrder.OrderPosition = new List<OrderPostition>();
            }
            decimal valueOfCart = 0;
            foreach(var item in shopCart)
            {
                var newOrderPosition = new OrderPostition()
                {
                    ItemId = item.Item.ItemId,
                    Quantity = item.stock,
                    orderPrice = item.Item.productPrice
                };
                valueOfCart += (item.stock * item.price);
                newOrder.OrderPosition.Add(newOrderPosition);
            }
            newOrder.orderValue = valueOfCart;
            db.SaveChanges();
                return newOrder ;
        }

        public void emptyCart()
        {
            session.Set<List<ShopCartPosition>>(Consts.ShopCartSessionKey, null);
        }

    }
}