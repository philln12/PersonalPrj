using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB1.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double BasePrice { get; set; }
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
    }
}
