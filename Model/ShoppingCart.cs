using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class ShoppingCart
    {
        //Instance Fields
        private List<Product> Products = new List<Product>();
        public User Customer { get; }

        //Constructors
        public ShoppingCart() 
        {
            
        }

        //Properties
        public double TotalAmount
        {
            get
            {
                double sum = 0;
                foreach (var x in Products)
                {
                    sum += x.Price;
                }
                return sum;
            }
        }

        //Methods
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        public List<Product> All()
        {
            return Products;
        }
    }
}
