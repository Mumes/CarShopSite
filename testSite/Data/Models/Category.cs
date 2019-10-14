using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testSite.Data.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public List<Car> Cars { get; set; }
    }
}
