using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    abstract class Product
    {
        private IProductOwner owner;
        private int price;
        public string description;
        private string name;

        public int Price { get => this.price; private set => this.price = value; }
        public string Name { get => name; private set => name = value; }
        public IProductOwner Owner { get => owner; private set => owner = value; }
        public Product(int price, string name, string description, IProductOwner owner = null)
        {
            this.price = price;
            this.description = description;
            Name = name;
            this.Owner = null;
        }

        /// <summary>
        /// Used for a user to signal they no longer own the product
        /// </summary>
        /// <param name="caller">should be the current owner of the product</param>
        internal void ReleaseOwnerShip(IProductOwner caller)
        {
            if (caller == owner)
            {
                owner = null;
            }
        }


        /// <summary>
        /// Lets a IProductOwner take ownership of the product.
        /// </summary>
        /// <param name="newOwner"></param>
        /// <returns>Did not have an owner already</returns>
        internal bool TakeOwnership(IProductOwner newOwner)
        {
            if(!HasOwner())
            {
                owner = newOwner;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasOwner()
        {
            return Owner != null;
        }

        // The requirement that it's the product that should have the purchase method makes it a bit more interesting.
        // The owner field and IProductOwner interface was added to handle logic of a transaction of the product.

        /// <summary>
        /// Asks if current owner will release ownership of the product. If so ask if buyer will take ownership.
        /// If the buyer can't take the product, the product now don't have an owner.
        /// </summary>
        /// <param name="buyer"> The IProductOwner that wants to take ownership of the product </param>
        public bool Purchase(IProductOwner buyer)
        {
            if(Owner.CesedeOwnerShip(this))
            {
                if(buyer.TakeOwnerShip(this))
                {
                    Owner = buyer;
                    return true;
                }
                else
                {
                    Owner = null;
                }
            }
            return false;
        }

        /// <summary>
        /// Prints how the product looks
        /// </summary>
        public void Examine()
        {
            Console.WriteLine(description);
        }

        /// <summary>
        /// Prints description of what happens when the user uses the item.
        /// </summary>
        abstract public void Use();


    }
}
