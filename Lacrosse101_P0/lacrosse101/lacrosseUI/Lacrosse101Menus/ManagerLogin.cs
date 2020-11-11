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
        private ReplenishInventory replenishInventory;

        public ManagerLogin(Manager manager, lacrosseContext context, ICustomerRepo custRepo, ILocationRepo locRepo)
        {
            this.manager = manager;
            this.custRepo = custRepo;
            this.locRepo = locRepo;
            this.custServices = new CustomerServices(custRepo);
            this.locServices = new LocationServices(locRepo);
            this.replenishInventory = new ReplenishInventory(manager, context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }

        public void Start()
        {
            do
            {
                System.Console.WriteLine("Please select an option below: ");
                System.Console.WriteLine("[0] Exit \n[1] Manage Inventory");

                manInput = System.Console.ReadLine();
                switch (manInput)
                {
                    case "1":
                        replenishInventory.Start();
                        break;
                    case "0":
                        System.Console.WriteLine($"Thank you, {manager.FirstName}. Goodbye!");
                        Environment.Exit(0);
                        break;
                }
            } while(!(manInput.Equals("0")));
        }
    }
}