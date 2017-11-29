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

        public Food(bool hot, string description, int price) : base(price,description)
        {
            this.hot = hot;
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
