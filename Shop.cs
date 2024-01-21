using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace OOP2_FINAL_PROJECT
{
    public class Shop : Entity
    {
        public string ShopName { get; set; }
        public int ShopCode { get; set; }
        public string ShopType { get; set; }
        public string ShopAddress { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Inventory ShopInventory { get; set; } = new Inventory();

        public List<Transaction> Sales { get; set; } = new List<Transaction>();
    }

}
