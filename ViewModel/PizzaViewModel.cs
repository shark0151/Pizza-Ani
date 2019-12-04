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
        //Instance Fields
        readonly Inventory inv = new Inventory();
        ShoppingCart sc = new ShoppingCart();
        OrderCatalog oc = new OrderCatalog();

        //Constructor
        public PizzaViewModel() { }

        //Methods
        //XAML Pages
        public void DisplayCart()
        {
            //code to display in xaml
        }

        public void DisplayOrders()
        {
            //code to display in xaml
        }

        //Orders
        public void CreateOrder()
        {
            oc.CreateOrder(sc);
        }

        public void DeactivateOrder()
        {
            oc._orderCatalog.Last().Active = false;
        }

        //Shopping Cart
        public void AddItemToCart(Product product)
        {
            sc.AddProduct(product);
        }

        public void RemoveItemFromCart(Product product)
        {
            sc.RemoveProduct(product);
        }
        public List<Product> GetInventory()
        {
            return inv.All();
        }

    }
}
