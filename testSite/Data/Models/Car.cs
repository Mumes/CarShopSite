using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testSite.Data.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string LongDecription { get; set; }
        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Avalibale { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
