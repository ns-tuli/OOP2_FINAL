using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_FINAL_PROJECT
{
    public class Product:Entity
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
