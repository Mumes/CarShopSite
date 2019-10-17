using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testSite.Data;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.allOrders = allOrders;
        }
        //[Route("Order/CheckOut")]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if(shopCart.ListShopItems.Count ==0)
            {
                ModelState.AddModelError("","Корзина пуста");
            }
            if(ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно сформирован";
            return View();
        }
    }
    
}
