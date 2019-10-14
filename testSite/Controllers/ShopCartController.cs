using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testSite.Data.Interfaces;
using testSite.Data.Models;
using testSite.Data.Repository;
using testSite.ViewModels;

namespace testSite.Controllers
{
    public class ShopCartController:Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var items = shopCart.GetShopItems();
            shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = this.shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = carRepository.Cars.FirstOrDefault(i => i.ID == id);
            if(item!=null)
             shopCart.AddToCart(item);
            return RedirectToAction("Index");
        }
    }
}
