using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class ShoppingCart
    {
        public List<Product> Products { get; }
        public double TotalAmmount
        {
            get
            {
                double sum = 0;
                foreach (var x in Products)
                {
                    sum = sum + x.Price;
                }
                return sum;
            }
        }
        public User Customer { get; }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

    }
}
