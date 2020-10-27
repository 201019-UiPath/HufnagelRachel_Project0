using System;

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
        int LocationId;
        string ManagerFirstName;
        string ManagerLastName;
        public void Start()
        {
            Console.WriteLine("Enter your credentials below: ");
            Console.WriteLine("LocationId: ");
            LocationId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("First Name: ");
            ManagerFirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            ManagerLastName = Console.ReadLine();
            Environment.Exit(0);
        }
    }
}