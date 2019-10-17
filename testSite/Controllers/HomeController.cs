using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testSite.Data.Interfaces;
using testSite.Data.Models;
using testSite.ViewModels;

namespace testSite.Controllers
{
    [Route("")]
    public class HomeController:Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;
        public HomeController(IAllCars carRepository, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {

            var homeCars = new HomeViewModel
            {
                FavCars = carRepository.GetFavCars
            };          
            return View(homeCars);
        }
    }
}
