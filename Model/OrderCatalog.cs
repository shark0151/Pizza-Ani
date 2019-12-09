using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class OrderCatalog
    {
        //Instance Fields
        public List<Order> _orderCatalog;

        //Constructor
        public OrderCatalog()
        {
            _orderCatalog=new List<Order>();
        }

        //Methods
        public void CreateOrder(ShoppingCart cart, User user)
        {
            Order NewOrder = new Order(cart.All(), user);
            NewOrder.Active = true;
            _orderCatalog.Add(NewOrder);
        }
    }
}
