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
        private Sticks sticks;
        private Balls balls;
        private int locationId;
        private Inventory inventory;
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
                        ManageInventoryforBalls(1);
                        ManageInventoryforSticks(1);
                        break;
                    case "4":
                        ManageInventoryforBalls(2);
                        ManageInventoryforSticks(3);
                        break;
                    case "6":
                        ManageInventoryforBalls(3);
                        ManageInventoryforSticks(3);
                        break;
                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }

            } while (true);
        }

        public void ManageInventoryforBalls(int locationId)
        {
            string manInput2;
            do
            {
                Console.WriteLine("Which ball item would you like to update?");
                List<Inventory> items = inventoryServices.GetAllOfInventoryByLocationId(locationId);
                foreach (Inventory item in items)
                {
                    Balls balls = productServices.GetBallByBallId(item.ballId);
                    Console.WriteLine($"[{balls.Id}]: Ball Color: {balls.colorType} ${balls.Price} Remaining in inventory: {item.quantityOfBalls}");
                }
                manInput2 = Console.ReadLine();
                Console.WriteLine("[0] Back");
                switch (manInput2)
                {
                    case "1":
                        updateBallStock(1);
                        break;

                    case "2":
                        updateBallStock(2);
                        break;

                    case "0":
                        break;
                }
            } while (!(manInput.Equals("0")));
        }

        public void ManageInventoryforSticks(int locationId)
        {
            string manInput2;
            do
            {
                Console.WriteLine("Which stick item would you like to update?");
                List<Inventory> items = inventoryServices.GetAllOfInventoryByLocationId(locationId);
                Console.WriteLine("[0] Back");
                foreach (Inventory item in items)
                {
                    Sticks sticks = productServices.GetStickByStickId(item.sticksId);
                    Console.WriteLine($"[{sticks.Id}]: Stick Brand: {sticks.brandType} ${sticks.Price} Remaining in inventory: {item.quantityOfSticks}");
                }
                manInput2 = Console.ReadLine();
                switch (manInput2)
                {
                    case "0":
                        break;

                    case "1":
                        updateStickStock(1);
                        break;

                    case "2":
                        updateStickStock(2);
                        break;
                    case "3":
                        updateStickStock(3);
                        break;
                    case "4":
                        updateStickStock(4);
                        break;
                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }
            } while (!(manInput.Equals("0")));
        }

        public void updateBallStock(int ballsId)
        {
            Console.WriteLine("How many of this item would you like to add?");
            int quantityToAdd = Int32.Parse(Console.ReadLine());

            while (quantityToAdd > 0)
            {
                Balls ball = new Balls();
                ball.Id = ballsId;
                productServices.AddProduct(ball);
                quantityToAdd--;
            }
        }

        public void updateStickStock(int stickId)
        {
            Console.WriteLine("How many of this item would you like to add?");
            int quantityToAdd = Int32.Parse(Console.ReadLine());
            while (quantityToAdd > 0)
            {
                Sticks stick = new Sticks();
                stick.Id = stickId;
                productServices.AddProduct(stick);
                quantityToAdd--;
            }
        }
    }
}