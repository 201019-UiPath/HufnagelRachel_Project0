using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class ProductDetails1 : IMenu
    {
        private string custInput;
        private Sticks sticks;
        private Customer customer;
        private lacrosseContext context;
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private IProductRepo productRepo;
        private ProductServices productServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryServices;
        private ProductDetails2 productDetails2;

        public ProductDetails1(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo)
        {
            this.customer = customer;
            this.context = context;
            this.customerRepo = customerRepo;
            this.inventoryRepo = inventoryRepo;
            this.productRepo = productRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.productServices = new ProductServices(productRepo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("Select From Our Lacrosse Sticks Below: ");
                List<Inventory> items = GetProductsForCustomerLocation();
                Console.WriteLine("[0] Exit");
                foreach(Inventory item in items)
                {
                    Sticks product = productServices.GetProductByStickId(item.stickId);
                    Console.WriteLine($"[{product.Id}]: {product.description}, ${product.Price}, remaining: {item.quantity}");
                }

                custInput = Console.ReadLine();
                switch (custInput)
                {
                    case "0":
                        break;
                        
                    case "1":
                        sticks = productServices.GetProductByStickId(1);
                        productDetails2 = new ProductDetails2(customer, sticks, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
                        productDetails2.Start();
                        break;

                    case "2":
                        sticks = productServices.GetProductByStickId(2);
                        productDetails2 = new ProductDetails2(customer, sticks, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
                        productDetails2.Start();
                        break;

                    case "3":
                        sticks = productServices.GetProductByStickId(3);
                        productDetails2 = new ProductDetails2(customer, sticks, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
                        productDetails2.Start();
                        break;

                    default:
                        Console.WriteLine("oppps");
                        ValidInvalidServices.InvalidInput();
                        break;
                }

            } while (!(custInput.Equals("0")));
        }

        public List<Inventory> GetProductsForCustomerLocation()
        {
            List<Inventory> items;
            int locationId = customer.LocationId;
            items = inventoryServices.GetAllOfInventoryByLocationId(locationId);
            return items;
        }
    }
}