using System;


namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// This is the menu for a new shopper 
    /// </summary>
    public class NewLoginMenu : IMenu
    {
        /// <summary>
        /// Here start() asks the new shopper to enter some information below 
        /// </summary>
        string NewFirstName;
        string NewLastName;
        string NewEmail;
        string password;

        public void Start()
        {
            Console.WriteLine("Please enter the information below: ");
            Console.WriteLine("First Name: ");
            NewFirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            NewLastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            NewEmail = Console.ReadLine();
            Console.WriteLine("Enter a password for your new shoppers account!");
            password = Console.ReadLine();
            Console.WriteLine($"Welcome to Lacrosse101 {NewFirstName} {NewLastName}!");
            //Environment.Exit(0);
        }

        
    }
}