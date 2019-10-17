using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
           
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c=>c.Category);

        public IEnumerable<Car> GetFavCars => appDBContent.Car.Where(p => p.IsFavorite).Include(c=>c.Category);

        

        public Car getObjectCar(int carID)
        {
           return appDBContent.Car.FirstOrDefault(p => p.ID == carID);
        }
    }
}
