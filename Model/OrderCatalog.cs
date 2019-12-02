using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class OrderCatalog
    {
        private List<Order> _orderCatalog;

        public void CreateOrder(ShoppingCart cart)
        {
            Order NewOrder = new Order(cart.Products, cart.Customer);
            _orderCatalog.Add(NewOrder);
        }
    }
}
