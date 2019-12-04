using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza_Ani_Time.Model;

namespace Pizza_Ani_Time.ViewModel
{
    class PizzaViewModel
    {
        Inventory inv;
        ShoppingCart sc;

        public PizzaViewModel()
        {
            inv = new Inventory();
            sc = new ShoppingCart();
        }
        public void displayCart()
        {
            //code to display in xaml
        }

        public List<Product> GetInventory()
        {
            return inv.All();
        }

    }
}
