using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class Product
    {
        //Instance Fields
        public string Name { get; }
        public string Image { get; }
        public double Price { get; }
        public string Details { get; }
        public string Category { get; }

        //Constructor
        public Product(string _name,string _image, double _price, string _details, string _cat)
        {
            Name = _name;
            Image = _image;
            Price = _price;
            Details = _details;
            Category = _cat;
        }
    }
}
