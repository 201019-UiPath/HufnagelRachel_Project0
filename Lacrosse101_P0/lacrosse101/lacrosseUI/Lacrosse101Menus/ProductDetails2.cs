using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class ProductDetails2 : IMenu
    {
        private string custInput;
        private Customer customer;
        private int inventoryQuantity;
        private Sticks stick;
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryServices;
        private IProductRepo productRepo;
        private ProductServices productServices;
        private ICartRepo cartRepo;
        private CartServices cartServices;
        private ICartItemsRepo cartItemsRepo;
        private CartItemServices cartItemServices;


        public ProductDetails2(Customer customer, Sticks stick, lacrosseContext context, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, ICartRepo cartRepo, ICartItemsRepo cartItemsRepo)
        {
            this.customer = customer;
            this.stick = stick;
            this.customerRepo = customerRepo;
            this.productRepo = productRepo;
            this.cartRepo = cartRepo;
            this.cartItemsRepo = cartItemsRepo;
            this.inventoryRepo = inventoryRepo;
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
                Inventory selected = inventoryServices.GetItemByLocIdStickId(customer.LocationId, stick.Id);
                inventoryQuantity = selected.quantity;

                Console.WriteLine("The item you have selected: ");
                Console.WriteLine($"{stick.description} \t${stick.Price}");

                Console.WriteLine("Would you like to add this item to cart?");
                Console.WriteLine("[0] No \n[1] Yes");
                custInput = Console.ReadLine();
                switch (custInput)
                {
                    case "0":
                        break;
                    case "1":
                        int quantity;

                        do
                        {
                            Console.WriteLine("How many would you like of this item?");
                            quantity = Int32.Parse(Console.ReadLine());
                        } while (ValidInvalidServices.InvalidQuanityOfItems(inventoryQuantity, quantity) == false);
                        CartItem ci = new CartItem();
                        Cart custCart = cartServices.GetCartByCustId(customer.Id);
                        ci.cartId = custCart.Id;
                        ci.stickId = stick.Id;
                        ci.quantity = quantity;
                        cartItemServices.AddCartItem(ci);
                        Console.WriteLine("Your item has been added to your cart");
                        break;
                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }
            } while (!(custInput.Equals("1")));
        }
    }
}