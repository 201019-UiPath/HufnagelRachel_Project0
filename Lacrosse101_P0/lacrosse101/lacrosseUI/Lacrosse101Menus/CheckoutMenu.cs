using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class CheckoutMenu : IMenu
    {
        private string custInput; 
        private Customer customer; 
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private ILocationRepo locationRepo;
        private LocationServices locationServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryServices;
        private IProductRepo productRepo; 
        private ProductServices productServices;
        private ICartRepo cartRepo; 
        private CartServices cartServices; 
        private ICartItemsRepo cartItemsRepo;
        private CartItemServices cartItemServices;
        private IOrderRepo orderRepo;
        private OrderServices orderServices;

        public CheckoutMenu(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, ILocationRepo locationRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, ICartRepo cartRepo, ICartItemsRepo cartItemsRepo, IOrderRepo orderRepo)
        {
            this.customer = customer; 
            this.customerRepo = customerRepo;
            this.inventoryRepo = inventoryRepo;
            this.locationRepo = locationRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.cartRepo = cartRepo;
            this.cartItemsRepo = cartItemsRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.locationServices = new LocationServices(locationRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.cartServices = new CartServices(cartRepo);
            this.cartItemServices = new CartItemServices(cartItemsRepo);
            this.orderServices = new OrderServices(orderRepo);
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}