using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// This is the login menu for a store manager
    /// </summary>
    public class ManagerLogin : IMenu
    {
        /// <summary>
        /// Here start() asks for the manager to input their credientals 
        /// </summary>
        private string manInput;
        private Manager manager;
        private ICustomerRepo custRepo;
        private CustomerServices custServices;
        private ILocationRepo locRepo;
        private LocationServices locServices;
        //private menu to edit the inventory

        public ManagerLogin(Manager manager, lacrosseContext context, ICustomerRepo custRepo, ILocationRepo locRepo)
        {
            this.manager = manager;
            this.custRepo = custRepo;
            this.locRepo = locRepo;
            this.custServices = new CustomerServices(custRepo);
            this.locServices = new LocationServices(locRepo);

            // declare a edit inventory menu here
        }

        public void Start()
        {
            do
            {
                System.Console.WriteLine("Welcome Manager, please select an option below: ");
                System.Console.WriteLine("[0] Manage Inventory \n[2] Exit");

                manInput = System.Console.ReadLine();
                switch (manInput)
                {
                    case "0":
                        // envove manager inventory menu
                        break;
                    case "2":
                        System.Console.WriteLine("Thank you, Manager. Goodbye!");
                        Environment.Exit(0);
                        break;
                }
            } while(!(manInput.Equals("2")));
        }
    }
}