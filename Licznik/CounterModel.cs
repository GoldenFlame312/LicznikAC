using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licznik
{
    public class CounterModel
    {


        public int count { get; set; }
        public string name { get; set; }
    

        public CounterModel(string name, int count)
        {
            

            this.name = name;
            this.count = count;
        }
        public CounterModel()
        { 
        
        }


       


    }
}

