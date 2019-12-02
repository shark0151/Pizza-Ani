using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Ani_Time.Model;

namespace Pizza_Ani_Time.Model
{
    class Order
    {
        public List<Product> Items { get; }
        public double TotalPrice
        {
            get
            {
                double sum = 0;
                foreach(var x in Items)
                {
                    sum = sum + x.Price;
                }
                return sum;
            }
        }
        public User Customer { get; }

        public bool Active { get; set; }//whatever

        public Order(List<Product> items,User user)
        {
            Items = items;
            Customer = user;
        }
    }
}
