using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending_Machine
{
    class VendingMachine : IProductOwner
    {
        public static readonly int[] denominations = { 1,2,5,10,20,50,100,200,500,1000};

        Queue<Product>[] stock;
        internal int moneyPool;
        private int slots;

        public int Slots { get => slots; private set => slots = value; }

        public VendingMachine(int slots = 5)
        {
            Slots = slots;
            stock = new Queue<Product>[slots];
            moneyPool = 0;
            for(int i = 0; i < slots; i++)
            {
                stock[i] = new Queue<Product>();
            }
        }

        /// <summary>
        /// Put a coin or bill into the machine
        /// </summary>
        /// <param name="money">should match an existing coin or bill </param>
        /// <returns>Vending machine accepted the money</returns>
        public bool AddMoney(int money)
        {
            if (!denominations.Contains(money))
            {
                return false;
            }
            else
            {
                moneyPool += money;
                return true;
            }
        }

        public int ReturnChange()
        {
            int change = moneyPool;
            moneyPool = 0;
            PrintChange(change);
            return change;
        }

        public static void PrintChange(int change)
        {   
            int[] changeArray = new int[denominations.Length];

            Console.Write("You get: ");
            for(int i = changeArray.Length - 1; i >= 0; i--)
            {
                int denominator = denominations[i];
                int count = change / denominator;
                change -= count * denominator;
                if (count != 0)
                {
                    Console.Write("{0} x {1}kr ", count, denominator);
                }
            }
            Console.Write("in change\n");
        }


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
                    Console.WriteLine("{0}: {1} {2}kr ", i, topProduct.Name, topProduct.Price);
                }
            }
        }

        /// <summary>
        /// Buy the top product in slot i;
        /// </summary>
        /// <param name="i">From what slot to buy</param>
        /// <returns>the purchased product or 'null'Purchase if failure to buy</returns>
        public bool BuyProduct(int i,IProductOwner buyer)
        {
            if (stock[i].Count() != 0)
            {
                Product productToSell = stock[i].Peek();
                return productToSell.Purchase(buyer);
            }
            return false;
           
        }

        /// <summary>
        /// Put a product at the bottom of the slot indicated by the slotIndex
        /// </summary>
        /// <param name="product">The product to add to the machine</param>
        /// <param name="slotIndex">In what slot to insert it</param>
        public void AddProduct(Product product, int slotIndex)
        {
            if(product.TakeOwnership(this))
                stock[slotIndex].Enqueue(product);
        }

        /// <summary>
        /// Removes the top product from a slot and return it
        /// </summary>
        /// <param name="slotIndex">slot to pop product from</param>
        internal Product RemoveProduct(int slotIndex)
        {
            if(stock[slotIndex].Count() != 0)
                return stock[slotIndex].Dequeue();
            else
            {
                return null;
            }
        }

        public bool TakeOwnerShip(Product product)
        {
            return product.TakeOwnership(this);
        }

        public bool CesedeOwnerShip(Product product)
        {
           foreach(var productStack in stock)
            {
                if(productStack.Count() != 0)
                {
                    if(productStack.Peek() == product && product.Price <= moneyPool)
                    {
                        moneyPool -= product.Price;
                        productStack.Dequeue();
                        product.ReleaseOwnerShip(this);
                        return true;
                    }
                }
            }
            return false;
        }

        internal void InspectProduct(int choice)
        {
            Console.Clear();
            stock[choice].Peek().Examine();
            Console.ReadKey();

        }
    }
}
