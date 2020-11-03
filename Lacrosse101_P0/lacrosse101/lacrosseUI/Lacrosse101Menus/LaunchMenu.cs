using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// this is the menu the shopper will see upon launching the store
    /// </summary>
    public class LaunchMenu : IMenu
    {
        private string shoperInput;
        private CustMenu custMenu;
        private ManagerLogin manLogin;
        private Customer customer;
        private ICustomerRepo custRepo;
        private CustomerServices customerServices;
        private ILocationRepo locRepo; 
        private LocationServices locationServices;
        private ICartRepo cartRepo;
        private CartServices cartServices;
        private lacrosseContext context;

        public LaunchMenu(lacrosseContext context, ICustomerRepo custRepo, ILocationRepo locRepo, ICartRepo cartRepo)
        {
            this.context = context;
            this.custRepo = custRepo;
            this.locRepo = locRepo;
            this.cartRepo = cartRepo;
            this.customerServices = new CustomerServices(custRepo);
            this.locationServices = new LocationServices(locRepo);
            this.cartServices = new CartServices(cartRepo);
        }
        

        /// <summary>
        /// Here start() allows the shopper/employee to be directed to the correct domain of the shop
        /// </summary>
        public void Start()
        {
            do 
            {  
                Console.WriteLine("Welcome to Lacrosse101, a store for all your lacrosse needs!");
                Console.WriteLine("Please choose one of the options below by typing the correspoing number.");
                Console.WriteLine("[0] Shop Equipment  \n[2] Store Manager Log In \n[4] Exit the store");
                shoperInput = Console.ReadLine();
                switch(shoperInput)
                {
                    case "0" :
                        Console.WriteLine("Welcome Shopper!");
                        custMenu.Start();
                        break;
                    case "2" : 
                        Console.WriteLine("Welcome Manager!");
                        manLogin.Start();
                        break;
                    case "4" :
                        Console.WriteLine("Goodbye!");
                        // this line will exit the current session 
                        Environment.Exit(0);
                        break;
                    default :
                        Console.WriteLine("You have entered an Invaid key, please try again");
                        break;
                }
            } while (!shoperInput.Equals("3"));
        }
    }
}