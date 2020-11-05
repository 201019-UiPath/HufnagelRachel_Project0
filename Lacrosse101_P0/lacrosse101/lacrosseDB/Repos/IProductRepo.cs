using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseDB.Repos
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductByProductType(int ProductType);
        Product GetProductByProductId(int Id);

        // instead of using linq update method 
        void SaveChanges();
    }
}