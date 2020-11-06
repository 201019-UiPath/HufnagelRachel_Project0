using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;


namespace lacrosseLib
{
    public class ProductServices
    {
        private IProductRepo prodRepo;

        public ProductServices(IProductRepo prodRepo)
        {
            this.prodRepo = prodRepo;
        }

        public void AddProduct(Product product) 
        {
            prodRepo.AddProduct(product);
        }

        public void DeleteProduct(Product product) 
        {
            prodRepo.DeleteProduct(product);
        }

        public Product GetProductByProductType(int prodType)
        {
            Product product = prodRepo.GetProductByProductType(prodType);
            return product;
        }

        public Product GetProductByProductId(int prodId)
        {
            Product product = prodRepo.GetProductByProductId(prodId);
            return product;
        }

        public List<Product> GetAllProductsByProductType(int prodType)
        {
            List<Product> prods = prodRepo.GetAllProductsByProductType(prodType);
            return prods;
        }

    }
}