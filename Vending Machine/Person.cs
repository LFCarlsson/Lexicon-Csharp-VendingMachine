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


        public void InspectProduct(int i)
        {
            if(ownedProducts.Count() > i)
            {
                Console.Clear();
                ownedProducts[i].Examine();
                Console.ReadKey(true);
            }
        }

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

        internal void PrintPocket()
        {
            for (int i = 0; i < ownedProducts.Count; i++)
            {
                Console.WriteLine("{0}) {1} ", i, ownedProducts[i].Name);
            }
        }
    }
}
