using System;

namespace lacrosseUI.Lacrosse101Menus
{
    public class LoginMenu : IMenu
    {
        public void Start()
        {
            string ShopperEmail;
            string ShopperPassword;
            
            // TODO: need to throw excption if the shopper does not enter the correct email format
            Console.WriteLine("Please enter your email below: ");
            ShopperEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password below: ");
            ShopperPassword = Console.ReadLine();
        }
    }
}