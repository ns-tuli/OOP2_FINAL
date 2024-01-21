using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_FINAL_PROJECT
{
    public interface IInventory
    {
        public void AddProduct(Product product, int quantity);
        public void RemoveProduct(Product product, int quantity);

        public int GetProductQuantity(Product product, int quantity);
    }
}
