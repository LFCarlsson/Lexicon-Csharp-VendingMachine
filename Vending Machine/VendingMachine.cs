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

        public VendingMachine(int slots = 5)
        {
            stock = new Stack<Product>[slots];
            for(int i = 0; i < slots; i++)
            {
                stock[i] = new Stack<Product>();
            }
        }

        internal int moneyPool;

        /// <summary>
        /// Print out the content of the vending machine.
        /// </summary>
        public void PrintStock()
        {
            for(int i = 0; i < stock.Length; i++ )
            {
                if(stock[i].Count == 0)
                {
                    Console.WriteLine("{0}: Empty",i);
                }
                else
                {
                    Product topProduct = stock[i].Peek();
                    Console.WriteLine("{0}: {1} {2}kr ", i, topProduct.description, topProduct.Price);
                }
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
