using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Data.Mocks
{
    public class CarRepostory : IAllCars
    {
        private readonly ICarsCategory carsCategory = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                      Name ="Tesla",
                      ShortDecription ="",
                      Img ="/img/15452119051460.jpg",
                      LongDecription ="",
                      IsFavorite =true,
                      Avalibale = true,
                      Price =45000,
                      Category = carsCategory.AllCategories.First()
                    },
                    new Car
                    {
                        Name ="Жигули",
                        ShortDecription ="",
                        Img ="/img/15452119051471.jpg",
                        LongDecription ="",
                        IsFavorite =true,
                        Avalibale = true,
                        Price =45000,
                        Category = carsCategory.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars{ get;}

        public Car getObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
