using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    abstract class Product
    {
        private int price;
        public string description;
        private string name;

        public int Price { get => this.price; private set => this.price = value; }
        public string Name { get => name; private set => name = value; }

        public Product(int price, string description)
        {
            this.price = price;
            this.description = description;
        }

        /// <summary>
        /// Subtract money from the vending machine if balance is high enough.
        /// </summary>
        /// <param name="vendingMachine">the vending machine to </param>
        /// <returns>Could or could not buy the product</returns>
        public bool Purchase(VendingMachine vendingMachine)
        {
            if(vendingMachine.moneyPool < price)
            {
                return false;
            }
            else
            {
                vendingMachine.moneyPool -= price;
                return true;
            }
        }

        /// <summary>
        /// Prints how the product looks
        /// </summary>
        public string Examine()
        {
            return "";
        }

        /// <summary>
        /// Prints description of what happens when the user uses the item.
        /// </summary>
        abstract public void Use();


    }
}
