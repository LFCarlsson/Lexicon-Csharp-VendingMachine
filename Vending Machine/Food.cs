using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Food : Product
    {
        bool hot;
        bool spicy;

        public Food(bool hot, bool spicy, string name, string description, int price) : base(price, name, description)
        {
            this.hot = hot;
            this.spicy = spicy;
        }

        public override void Use()
        {
            string result = "You eat the " + this.Name;
            if (hot)
            {
                result += " it's hot";
                if (spicy)
                {
                    result += " and";
                }
            }
            if (spicy) {
                result += " it's spicy";
            }
            Owner.CesedeOwnerShip(this);
        }
    }
}
