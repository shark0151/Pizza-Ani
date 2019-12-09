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
        readonly Inventory inv = new Inventory(); //make staticc?
        static ShoppingCart sc = new ShoppingCart(); //should be static
        OrderCatalog oc = new OrderCatalog();

        public event PropertyChangedEventHandler PropertyChanged;

        //
        public int CartNumber { get { return GetCart().Count; } }
        public string CartTotal { get { return sc.TotalAmount.ToString()+" kr"; } }

        //Constructor
        public PizzaViewModel() {}

        //Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


    }
}
