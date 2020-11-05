using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class ProductDetails : IMenu
    {
        private string custInput;
        private int quantity;
        private Sticks sticks;
        private Balls balls;
        private Customer customer;
        private lacrosseContext context;
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private IProductRepo productRepo;
        private ProductServices productServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryServices;
        private ICartRepo cartRepo;
        private CartServices cartServices;
        private ICartItemsRepo cartItemsRepo;
        private CartItemServices cartItemServices;

        public ProductDetails(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, ICartRepo cartRepo, ICartItemsRepo cartItemsRepo)
        {
            this.customer = customer;
            this.context = context;
            this.customerRepo = customerRepo;
            this.inventoryRepo = inventoryRepo;
            this.productRepo = productRepo;
            this.cartRepo = cartRepo;
            this.cartItemsRepo = cartItemsRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.productServices = new ProductServices(productRepo);
            this.cartServices = new CartServices(cartRepo);
            this.cartItemServices = new CartItemServices(cartItemsRepo);
        }

        public void Start()
        {
            do
            {
                int locationId = customer.LocationId;
                Console.WriteLine("Select from our products below: ");
                List<Inventory> items = inventoryServices.GetAllOfInventoryByLocationId(locationId);
                Console.WriteLine("How many would you like of this item?");
                quantity = Int32.Parse(Console.ReadLine());
                CartItem cartItem = new CartItem();
                Cart custCart = cartServices.GetCartByCustId(customer.Id);
                Console.WriteLine("[0] Exit");
                foreach (Inventory item in items)
                {
                    Product product = productServices.GetProductByProductId(item.Id);
                    if (product.ProductType == 0)
                    {
                        Console.WriteLine("_____ \tLacrosse Sticks: _____");
                        Console.WriteLine($" [{product.Id}]:  ${product.Price}, remaining: {item.quantityOfSticks}");
                    }
                    else if (product.ProductType == 1)
                    {
                        Console.WriteLine("_____ \tLacrosse Balls: _____");
                        Console.WriteLine($" [{product.Id}]:  ${product.Price}, remaining: {item.quantityOfBalls}");
                    }
                    custInput = Console.ReadLine();
                    switch (custInput)
                    {
                        case "0":
                            break;
                        case "1":
                            cartItem.cartId = custCart.Id;
                            cartItem.ballId = balls.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        case "2":
                            cartItem.cartId = custCart.Id;
                            cartItem.ballId = balls.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        case "3":
                            cartItem.cartId = custCart.Id;
                            cartItem.stickId = sticks.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        case "4":
                            cartItem.cartId = custCart.Id;
                            cartItem.stickId = sticks.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        case "5":
                            cartItem.cartId = custCart.Id;
                            cartItem.stickId = sticks.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        case "6":
                            cartItem.cartId = custCart.Id;
                            cartItem.stickId = sticks.Id;
                            cartItem.quantity = quantity;
                            cartItemServices.AddCartItem(cartItem);
                            Console.WriteLine("Item added to cart.");
                            break;

                        default:
                            ValidInvalidServices.InvalidInput();
                            break;
                    }
                }
            } while (!(custInput.Equals("0")));
        }
    }
}