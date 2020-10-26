using System;


namespace lacrosseUI.Lacrosse101Menus
{
    public class NewLoginMenu : IMenu
    {
        string NewFirstName;
        string NewLastName;
        string NewEmail;

        public void Start()
        {
            Console.WriteLine("Please enter the information below: ");
            Console.WriteLine("First Name: ");
            NewFirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            NewLastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            NewEmail = Console.ReadLine();
            Console.WriteLine($"Welcome to Lacrosse101 {NewFirstName} {NewLastName}!");
        }

        
    }
}