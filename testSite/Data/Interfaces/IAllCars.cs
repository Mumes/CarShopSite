using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testSite.Data.Models;

namespace testSite.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get;  }
        IEnumerable<Car> GetFavCars { get; }
        Car getObjectCar(int carID);
    }
}
