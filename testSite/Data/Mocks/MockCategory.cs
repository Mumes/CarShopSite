using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name= "Электромобили", Decription = "Современный вид транспорта"},
                    new Category { Name = "Классические автомобили", Decription = "Автомобили с двигателем внутреннего сгорания"}
                };
            }
            
        }
    }
       
}
