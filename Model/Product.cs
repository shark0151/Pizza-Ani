using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class Product
    {
        public string Name { get; }
        public string Image { get; }
        public double Price { get; }
        public string Details { get; }

        public Product(string _name,string _image, double _price, string _details)
        {
            Name = _name;
            Image = _image;
            Price = _price;
            Details = _details;
        }
    }
}
