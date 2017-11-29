using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    interface IProductOwner
    {
        void TakeOwnerShip(Product product);
        void CesedeOwnerShip(Product ownership);
        void TransferOwnerShip(Product product, IProductOwner newOwner);
    }
}
