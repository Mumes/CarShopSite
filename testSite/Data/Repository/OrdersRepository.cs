using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDBContent = appDBContent;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            var items = shopCart.ListShopItems;
            foreach (var elem in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarId = elem.Car.ID,
                    OrderId = order.Id,
                    Price = elem.Car.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
