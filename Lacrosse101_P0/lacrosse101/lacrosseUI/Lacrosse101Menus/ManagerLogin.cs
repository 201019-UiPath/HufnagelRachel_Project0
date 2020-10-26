using System;

namespace lacrosseUI.Lacrosse101Menus
{
    public class ManagerLogin : IMenu
    {
        string LocationId;
        string ManagerFirstName;
        string ManagerLastName;
        public void Start()
        {
            Console.WriteLine("Welcome Manager! Enter your credentials below: ");
            Console.WriteLine("LocationId: ");
            LocationId = Console.ReadLine();
            Console.WriteLine("First Name: ");
            ManagerFirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            ManagerLastName = Console.ReadLine();
        }
    }
}