using System;

namespace Vending_Machine
{
    class Snack : Product
    {
        string taste;

        public Snack(string taste, string description, int price) : base(price,description)
        {
            this.taste = taste;
        }
        public override void Use()
        {
            Console.WriteLine("You eat the " + taste + " Snack");
        }
    }
}
