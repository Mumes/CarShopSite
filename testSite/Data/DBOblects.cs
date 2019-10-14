using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using testSite.Data.Models;

namespace testSite.Data
{
    public class DBOblects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c=>c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDecription = "",
                        Img = "/img/15452119051460.jpg",
                        LongDecription = "",
                        IsFavorite = true,
                        Avalibale = true,
                        Price = 45000,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Жигули",
                        ShortDecription = "",
                        Img = "/img/15452119051471.jpg",
                        LongDecription = "",
                        IsFavorite = true,
                        Avalibale = true,
                        Price = 45000,
                        Category = Categories["Классические автомобили"]
                    }
                    );
                content.SaveChanges();
            }
                
        }
        private static Dictionary<string, Category> category;
        private static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { Name= "Электромобили", Decription = "Современный вид транспорта"},
                        new Category { Name = "Классические автомобили", Decription = "Автомобили с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (var c in list)
                    {
                        category.Add(c.Name, c);
                    }
                    return category;
                }
                return category;
            }

        }
    }
}
