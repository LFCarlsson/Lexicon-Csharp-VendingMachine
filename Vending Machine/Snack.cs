using System;

namespace Vending_Machine
{
    class Snack : Product
    {
        string taste;

        public Snack(string taste, string name, string description, int price) : base(price, name, description)
        {
            this.taste = taste;
        }

        public override void Use()
        {
            Console.WriteLine("You eat the " + taste + " Snack");
            Owner.CesedeOwnerShip(this);
        }
    }
}
