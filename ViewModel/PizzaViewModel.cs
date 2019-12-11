using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Pizza_Ani_Time.Model;

namespace Pizza_Ani_Time.ViewModel
{
    public class PizzaViewModel : INotifyPropertyChanged
    {

        //Instance Fields
        readonly Inventory inv = new Inventory(); //make static?
        static ShoppingCart sc = new ShoppingCart(); //should be static
        static OrderCatalog oc = new OrderCatalog();
        User Hero = new User();
        public event PropertyChangedEventHandler PropertyChanged;

        //
        public int CartNumber { get { return GetCart().Count; } }
        public string CartTotal { get { return sc.TotalAmount.ToString() + " kr"; } }

        //Constructor
        public PizzaViewModel() { }

        //Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CreateUser()
        {
            Hero.SetName("Johnny Storm");
            Hero.SetID();
        }

        //Orders
        public void CreateOrder()
        {
            oc.CreateOrder(sc, Hero);
        }

        public void DeactivateOrder(Order o)
        {
            oc._orderCatalog.Find(x => x == o).Active = false;
        }

        //Shopping Cart
        public void AddItemToCart(Product product)
        {
            sc.AddProduct(product);
            //CartNumber++;
            OnPropertyChanged("CartNumber");
            OnPropertyChanged("CartTotal");
        }

        public void RemoveItemFromCart(Product product)
        {
            //CartNumber--;
            sc.RemoveProduct(product);
            OnPropertyChanged("CartNumber");
            OnPropertyChanged("CartTotal");

        }
        public List<Product> GetInventory()
        {
            return inv.All();
        }

        public List<Product> GetCart()
        {
            return sc.All();
        }

        public void DeleteShoppingCart()
        {
            sc.ClearShoppingCart();
            OnPropertyChanged("CartNumber");
            OnPropertyChanged("CartTotal");
        }

        public List<Order> GetActiveOrders()
        {
            return oc.GetActiveOrders();
        }

        public List<Order> GetRecentOrders()
        {
            return oc.GetRecentOrders();
        }
    }
}
