using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_FINAL_PROJECT
{
    public static class Validation
    {
        
        public static bool IsShopValid(Shop shop)
        {
            // Add your validation logic here
            return !string.IsNullOrEmpty(shop.ShopName) && !string.IsNullOrEmpty(shop.ShopType);
        }
    }
}
