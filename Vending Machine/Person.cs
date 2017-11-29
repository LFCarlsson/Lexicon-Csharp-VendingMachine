using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Person : IProductOwner
    {
        public void CesedeOwnerShip(Product ownership)
        {
            throw new NotImplementedException();
        }

        public void TakeOwnerShip(Product product)
        {
            throw new NotImplementedException();
        }

        public void TransferOwnerShip(Product product, IProductOwner newOwner)
        {
            throw new NotImplementedException();
        }
    }
}
