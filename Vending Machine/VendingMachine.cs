using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class VendingMachine
    {

        Stack<Product>[] stock;

        public VendingMachine(int slots = 10)
        {
            stock[slots] = new Stack<Product>();
        }

        internal int moneyPool;
        public void PrintStock()
        {
            foreach(Stack<Product> slot in stock)
            {
                //TODO: Continue here
            }
        }
        public void AddProduct(Product product)
        {

        }
        internal void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
