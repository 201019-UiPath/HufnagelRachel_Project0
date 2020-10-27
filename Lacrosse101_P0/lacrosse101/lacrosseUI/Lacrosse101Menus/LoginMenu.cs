using System;

namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// This is the log in menu for a returning shopper
    /// </summary>
    public class LoginMenu : IMenu
    {
        /// <summary>
        /// Here start() asks for the returning shoppers email and password
        /// </summary>
        public void Start()
        {
            string ShopperEmail;
            string ShopperPassword;
            
            // TODO: need to throw excption if the shopper does not enter the correct email format
            Console.WriteLine("Please enter your email below: ");
            ShopperEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password below: ");
            ShopperPassword = Console.ReadLine();
            Environment.Exit(0);
        }
    }
}