using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine;

namespace Vending_Machine {

    class Hat : Product
    {
        bool on;
        public Hat(string name, string description, int price) : base(price, name, description)
        {
            on = false;
        }
        public override void Use()
        {
            on = !on;
            if(on)
            {
                Console.WriteLine("You put the hat on");
            }
            else
            {
                Console.WriteLine("You take off the hat");
            }
        }
    }

}
