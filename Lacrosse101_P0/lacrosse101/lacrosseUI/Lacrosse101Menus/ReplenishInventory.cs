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
        private string manInput2;
        private Manager manager;
        private int selectedLoc;
        private Sticks sticks;
        private Inventory Selectedinventory;
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
                Console.WriteLine("[0] Exit \n[1] Location 1 \n[2] Location 2 \n[3] Location 3");

                manInput = Console.ReadLine();
                selectedLoc = Int32.Parse(manInput);
                switch (manInput)
                {
                    case "0":
                        break;

                    case "1":
                        ManageInventory(1);
                        break;

                    case "2":
                        ManageInventory(2);
                        break;

                    case "3":
                        ManageInventory(3);
                        break;

                    default:
                        Console.WriteLine("oops");
                        ValidInvalidServices.InvalidInput();
                        break;
                }

            } while (!(manInput.Equals("0")));
        }

        public List<Inventory> GetProductsByLocation(int locId)
        {
            List<Inventory> inventories = inventoryServices.GetAllOfInventoryByLocationId(locId);
            return inventories;
        }

        public void ManageInventory(int locationId)
        {
            do
            {
                Console.WriteLine("Select which item to replenish by selecting the number in brackets.");
                List<Inventory> items = GetProductsByLocation(locationId);
                Console.WriteLine("[0] Back");

                foreach (Inventory item in items)
                {
                    Sticks product = productServices.GetProductByStickId(item.stickId);
                    Console.WriteLine($"[{product.Id}] {product.description}, remaining: {item.quantity}");
                }
                manInput2 = Console.ReadLine();
                switch (manInput2)
                {
                    case "0":
                        break;
                    case "1":
                        updateStock(1);
                        break;
                    case "2":
                        updateStock(2);
                        break;
                    case "3":
                        updateStock(3);
                        break;
                    default:
                        Console.WriteLine("oops");
                        ValidInvalidServices.InvalidInput();
                        break;
                }
            } while(!(manInput2.Equals("0")));
        }

        public void updateStock(int stickId)
        {
            Selectedinventory = inventoryServices.GetItemByLocIdStickId(selectedLoc, stickId);
            Console.WriteLine("How much of this item would you like to add to the inventory?");
            int toAdd = Int32.Parse(Console.ReadLine());
            Selectedinventory.quantity = toAdd + Selectedinventory.quantity;
            inventoryServices.UpdateInventory(Selectedinventory);
            Console.WriteLine("The stock of this item has been updated!");
        }
    }
}