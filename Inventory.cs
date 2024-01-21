using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2_FINAL_PROJECT;

namespace OOP2_FINAL_PROJECT
{
    public class Inventory : IInventory
    {
        private Dictionary<Product, int> stock = new Dictionary<Product, int>();

        Product product;

        public void AddProduct(Product product, int quantity)
        {
            if (stock.ContainsKey(product))
            {
                stock[product] += quantity;
            }
            else
            {
                stock.Add(product, quantity);
            }
        }

        public void RemoveProduct(Product product, int quantity)
        {
            if (stock.ContainsKey(product) && stock[product] >= quantity)
            {
                stock[product] -= quantity;
            }
        }

         public  int GetProductQuantity(Product product, int quantity)
        {
            return stock.ContainsKey(product) ? stock[product] : 0;

        }

        
    }
}
