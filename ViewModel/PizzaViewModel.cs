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
        readonly Inventory inv = new Inventory();
        ShoppingCart sc = new ShoppingCart();
        OrderCatalog oc = new OrderCatalog();


        public PizzaViewModel() { }

        public void DisplayCart()
        {
            //code to display in xaml
        }

        public void DeactivateOrder()
        {
            oc._orderCatalog.Last().Active = false;
        }

        public void CreateOrder()
        {
            oc.CreateOrder(sc);
        }

        public void AddItemToCart(Product product)
        {
            sc.AddProduct(product);
        }

        public void RemoveItemFromCart(Product product)
        {
            sc.RemoveProduct(product);
        }
    }
}
