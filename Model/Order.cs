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
        public List<Product> Products { get; }
        public double TotalAmmount
        {
            get
            {
                double sum = 0;
                foreach(var x in Products)
                {
                    sum = sum + x.Price;
                }
                return sum;
            }
        }
        public User Customer { get; }

        public bool Active { get; }

        public Order(List<Product> products,User user)
        {
            Products = products;
            Customer = user;
        }
    }
}
