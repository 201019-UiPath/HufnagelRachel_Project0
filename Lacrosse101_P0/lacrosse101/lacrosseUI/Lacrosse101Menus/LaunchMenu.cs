using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;
using Serilog;

namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// this is the menu the shopper will see upon launching the store
    /// </summary>
    public class LaunchMenu : IMenu
    {
        private string shoperInput;
        private CustMenu custMenu;
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
            Manager man = new Manager();
            ManagerLogin manLogin = new ManagerLogin(man, context, new DBRepo(context), new DBRepo(context));
            do
            {
                Console.WriteLine("Welcome to Lacrosse101, a store for all your lacrosse needs!");
                Console.WriteLine("Please choose one of the options below by typing the correspoing number.");
                Console.WriteLine("[0] Returning Shopper Shop Equipment Here \n[1] New Shopper \n[2] Store Manager \n[4] Exit the store");
                shoperInput = Console.ReadLine();
                switch (shoperInput)
                {
                    case "0":
                        Console.WriteLine("Welcome Shopper!");
                        Customer cust = CustomerValidation();
                        break;
                    case "1":
                        Customer newCust = NewCustomerValidation();
                        customerServices.AddCustomer(newCust);
                        break;
                    case "2":
                        Console.WriteLine("Welcome Manager!");
                        manLogin.Start();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        // this line will exit the current session 
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You have entered an Invaid key, please try again");
                        break;
                }
            } while (!shoperInput.Equals("3"));
        }

        public Customer CustomerValidation()
        {
            string filepath = "../lacrosseDB/DBFiles/Customer.txt";
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(filepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            string email;
            Customer cust = new Customer();
            Console.WriteLine("Enter email");
            email = Console.ReadLine();
            try
            {
                cust = customerServices.GetCustomerByEmail(email);
                if (cust.email != email)
                    throw new System.ArgumentException();
                else
                {
                    customer = cust;
                    Log.Information($"{cust.email} has signed in");
                    CustMenu custMenu = new CustMenu(customer, context);
                    try
                    {
                        cartServices.DeleteCart(cartServices.GetCartByCustId(customer.Id));
                    }
                    catch (InvalidOperationException) { }
                    finally
                    {
                        Cart newCart = new Cart();
                        newCart.custId = customer.Id;
                        cartServices.AddCart(newCart);
                        custMenu.Start();
                    }
                }
            }
            catch (ArgumentException)
            {
                Log.Information($"Customer {cust.email} tried and failed to login.");
                ValidInvalidServices.InvalidInput();
            }
            catch (InvalidOperationException)
            {
                Log.Information($"Customer tried to sign into an account the DNE.");
                ValidInvalidServices.InvalidInput();
            }
            return cust;
        }

        public Customer NewCustomerValidation()
        {
            string NewLoc;
            List<Customer> custs = customerServices.GetAllCustomers();
            Customer cust = new Customer();
            do
            {
                Console.WriteLine("Enter First Name: ");
                cust.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                cust.LastName = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                cust.email = Console.ReadLine();
            } while (ValidInvalidServices.ValidUniqueEmail(cust.email, custs) == false);
            Boolean keepRunning = true;
            do
            {
                Console.WriteLine("Choose from the follow locations: ");
                Console.WriteLine("[1] Location 1 \n[2] Location 2 \n[3] Location 3");
                NewLoc = Console.ReadLine();
                switch (NewLoc)
                {
                    case "1":
                        cust.LocationId = 1;
                        keepRunning = false;
                        break;

                    case "2":
                        cust.LocationId = 2;
                        keepRunning = false;
                        break;

                    case "3":
                        cust.LocationId = 3;
                        keepRunning = false;
                        break;

                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }
            } while (keepRunning);
            Console.WriteLine("New Customer Created");
            return cust;
        }
    }
}