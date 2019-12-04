using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class OrderCatalog
    {
        public List<Order> _orderCatalog;

        public OrderCatalog() { }

        public void CreateOrder(ShoppingCart cart)
        {
            Order NewOrder = new Order(cart.Products, cart.Customer);
            NewOrder.Active = true;
            _orderCatalog.Add(NewOrder);
        }
    }
}
