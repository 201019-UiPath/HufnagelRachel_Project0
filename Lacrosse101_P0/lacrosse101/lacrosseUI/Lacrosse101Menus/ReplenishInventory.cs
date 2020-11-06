using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class ReplenishInventory : IMenu
    {
        private string manInput;
        private Manager manager;
        // private Sticks sticks;
        // private Balls balls;
        //private int locationId;
        //private Inventory inventory;
        private ProductServices productServices;
        private LocationServices locationServices;
        private InventoryServices inventoryServices;
        private IProductRepo productRepo;
        private ILocationRepo locationRepo;
        private IInventoryRepo inventoryRepo;
        private lacrosseContext context;

        public ReplenishInventory(Manager manager, lacrosseContext context, ILocationRepo locationRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo)
        {
            this.manager = manager;
            this.context = context;
            this.locationRepo = locationRepo;
            this.inventoryRepo = inventoryRepo;
            this.productRepo = productRepo;

            this.locationServices = new LocationServices(locationRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.productServices = new ProductServices(productRepo);
        }
        public void Start()
        {
            do
            {
                Console.WriteLine("Welcome manager, follow the steps below to replenish the stock.");

                Console.WriteLine("Select a location to replenish inventory at:");
                Console.WriteLine("[0] Exit \n[2] Location 1 \n[4] Location 2 \n[6] Location 3");

                manInput = Console.ReadLine();
                switch (manInput)
                {
                    case "0":
                        break;
                    case "2":
                        ManageInventory(1);
                        break;
                    case "4":
                        ManageInventory(2);
                        break;
                    case "6":
                        ManageInventory(3);
                        break;
                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }

            } while (true);
        }

        public void ManageInventory(int locationId)
        {
            string manInput2;
            do
            {
                Console.WriteLine("Select which item to replenish by selecting the number in brackets.");
                List<Inventory> items = inventoryServices.GetAllOfInventoryByLocationId(locationId);
                foreach (Inventory item in items)
                {
                    Product product = productServices.GetProductByProductId(item.Id);
                    if (product.ProductType == 0)
                    {
                        Console.WriteLine("_____ Lacrosse Sticks: _____");
                        Console.WriteLine($" [{product.Id}]:  {product.description}, remaining: {item.quantityOfSticks}");
                    }
                    else if (product.ProductType == 1)
                    {
                        Console.WriteLine("_____ Lacrosse Balls: _____");
                        Console.WriteLine($" [{product.Id}]:  {product.description}, remaining: {item.quantityOfBalls}");
                    }
                }
                Console.WriteLine("[0] Back");
                manInput2 = Console.ReadLine();
                switch (manInput2)
                {
                    case "1":
                        updateStock(1);
                        break;

                    case "2":
                        updateStock(2);
                        break;

                    case "0":
                        break;
                }
            } while (!(manInput.Equals("0")));
        }

        // this needs to be updated
        public void updateStock(int prodId)
        {
            string manInput2;
            Console.WriteLine("Would you like to update the \n[0] lacrosse balls or \n[1] lacrosse sticks?");
            manInput2 = Console.ReadLine();
            if (manInput.Equals("0"))
            {
                Console.WriteLine("How many of lax balls would you like to add?");
                int quantityToAdd = Int32.Parse(Console.ReadLine());
                while (quantityToAdd > 0)
                {
                    Product product = new Balls();
                    product.Id = prodId;
                    //inventoryServices.UpdateInventory(product);
                    quantityToAdd--;
                    Console.WriteLine("adding...");
                }
            } else if (manInput2.Equals("1")) {
                Console.WriteLine("How many of lacrosse sticks would you like to add?");
                int quantityToAdd = Int32.Parse(Console.ReadLine());
                while (quantityToAdd > 0)
                {
                    Product product = new Balls();
                    product.Id = prodId;
                    //inventoryServices.UpdateInventory(product);
                    quantityToAdd--;
                    Console.WriteLine("adding...");
                }
            } else {
                ValidInvalidServices.InvalidInput();
            }
        }
    }
}