using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Person : IProductOwner
    {
        public List<Product> ownedProducts;
        private int money;

        public Person(int userMoney)
        {
            this.Money = userMoney;
            ownedProducts = new List<Product>();
        }

        public int Money { get => money; set => money = value; }

        /// <summary>
        /// Prints the description of the object in slot i
        /// </summary>
        /// <param name="i">slot in ownedProduct</param>
        public void InspectProduct(int i)
        {
            if(ownedProducts.Count() > i)
            {
                Console.Clear();
                ownedProducts[i].Examine();
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Remove Product from ownedProducts and stop being it's owner
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Allowed ceseding ownership</returns>
        public bool CesedeOwnerShip(Product product)
        {
            if(ownedProducts.Contains(product) && product.Owner == this)
            {
                ownedProducts.Remove(product);
                product.ReleaseOwnerShip(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Put the Product into ownedProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns>could take ownership</returns>
        public bool TakeOwnerShip(Product product)
        {
            if(!ownedProducts.Contains(product) && !product.HasOwner())
            {
                product.TakeOwnership(this);
                ownedProducts.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Print out the content of ownedProducts
        /// </summary>
        public void PrintPocket()
        {
            for (int i = 0; i < ownedProducts.Count; i++)
            {
                Console.WriteLine("{0}) {1} ", i, ownedProducts[i].Name);
            }
        }
    }
}
