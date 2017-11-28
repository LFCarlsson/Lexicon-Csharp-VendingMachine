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

        public int Price { get; private set; }

        /// <summary>
        /// Subtract money and self from the vendingMachine.
        /// </summary>
        /// <param name="vendingMachine">the vendingmachine to </param>
        /// <returns>It</returns>
        public Product Purchase(VendingMachine vendingMachine)
        {
            if(vendingMachine.moneyPool < price)
            {
                throw (new ApplicationException("Insufficient balance in vending machine"));
            }
            else
            {
                vendingMachine.moneyPool -= price;
                vendingMachine.RemoveProduct(this);
                return this;
            }
        }

        /// <summary>
        /// Returns how the product looks
        /// </summary>
        /// <returns>A description of the item</returns>
        public string Examine()
        {
            return "";
        }

        /// <summary>
        /// Description of what happens when the user uses the item.
        /// </summary>
        /// <returns>Description of usage</returns>
        abstract public string Use();


    }
}
