using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Person : IProductOwner
    {
        private List<Product> ownedProducts;
        private int money;

        public Person(int userMoney)
        {
            this.Money = userMoney;
        }

        public int Money { get => money; private set => money = value; }



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
    }
}
