using System;

namespace lacrosseUI.Lacrosse101Menus
{
    /// <summary>
    /// this is the menu the shopper will see upon launching the store
    /// </summary>
    public class LaunchMenu : IMenu
    {
        /// <summary>
        /// Here start() allows the shopper/employee to be directed to the correct domain of the shop
        /// </summary>
        public void Start()
        {
            string shoperInput;
            do 
            {
                
                Console.WriteLine("Welcome to Lacrosse101, a store for all your lacrosse needs!");
                Console.WriteLine("Please choose one of the options below by typing the correspoing number.");
                Console.WriteLine("[0] New Shopper? Sign Up! \n[1] Returing shopper? Log In Here!  \n[2] Store Manager? Log In Here! \n[3] Exit the store.");
                shoperInput = Console.ReadLine();
                switch(shoperInput)
                {
                    case "0" :
                        Console.WriteLine("Welcome New User!");
                        NewLoginMenu newLogin = new NewLoginMenu();
                        newLogin.Start();
                        break;
                    case "1" : 
                        Console.WriteLine("Welcome Back!");
                        LoginMenu login = new LoginMenu();
                        login.Start();
                        break;
                    case "2" : 
                        Console.WriteLine("Welcome Manager!");
                        ManagerLogin manlogin = new ManagerLogin();
                        manlogin.Start();
                        break;
                    case "3" :
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