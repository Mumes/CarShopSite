using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testSite.Data.Interfaces;
using testSite.ViewModels;

namespace testSite.Controllers
{
    public class CarsController:Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCategories;
       
        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            this.allCars = allCars;
            this.allCategories = allCategories;
        }
       
        public ViewResult List()
        {
            ViewBag.Title = "Страница с авто";
            CarsListViewModel cars = new CarsListViewModel();
            cars.AllCars=allCars.Cars;
            cars.CurrentCategory = "Авто";
             return View(cars);
            
        }
    }
}
