using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseDB
{
    public interface IProductRepo
    {
        void AddMoreProductToLocation(List<Product> newProduct, int locationId);

        void RemoveProductFromLocation(List<Product> removedProduct, int locationId);
         
    }
}