using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Ani_Time.Model
{
    class User
    {
        //Instance Fields
        string Name { get; set;}
        string ID { get; set; }//must autogenerate and check for duplicates

        public void SetName(string name)
        {
            Name = name;
        }
        public void SetID()
        {
            ID = "xxx";
        }
    }
}
