using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_FINAL_PROJECT
{
    public class Transaction : Entity
    {
        public DateTime Date { get; set; }
        public double TotalAmount { get; set; }
        public List<Product> PurchasedProducts { get; set; } = new List<Product>();
    }
}
