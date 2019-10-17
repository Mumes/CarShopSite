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
    public class CarsController:Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCategories;
       
        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            this.allCars = allCars;
            this.allCategories = allCategories;
        }
       
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Car> carsList = null;
            string currCategory = null;
            if (string.IsNullOrEmpty(category))
                carsList = allCars.Cars.OrderBy(i => i.ID);
            else if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                carsList = allCars.Cars.Where(c => c.Category.Name.Equals("Электромобили")).OrderBy(i => i.ID);
                currCategory = "Электромобили";
            }
            else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                carsList = allCars.Cars.Where(c => c.Category.Name.Equals("Классические автомобили")).OrderBy(i => i.ID);
                currCategory = "Автомобили с бензиновым двигателем";
            }
            
            var carObj = new CarsListViewModel { AllCars = carsList, CurrentCategory = currCategory };
            ViewBag.Title = "Страница с авто";            
             return View(carObj);
            
        }
    }
}
