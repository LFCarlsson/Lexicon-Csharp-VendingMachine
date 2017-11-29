using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Drink : Product
    {
        bool fizzy;
        bool hot;

        public Drink(bool fizzy, bool hot, string description, int price) : base(price,description)
        {
            this.fizzy = fizzy;
            this.hot = hot;
        }

        public override void Use()
        {
            string effect = "The drink is ";
            if(hot)
            {
                effect += "hot";
            }
            else
            {
                effect += "cold";
            }
            if(fizzy)
            {
                effect += " and fizzy.";
            }
            effect += " Very refreshing!";

            Console.WriteLine(effect);
        }
    }
}
