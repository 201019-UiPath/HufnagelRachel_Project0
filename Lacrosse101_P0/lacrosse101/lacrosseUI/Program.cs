using System;
using lacrosseUI.Lacrosse101Menus;

namespace lacrosseUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            IMenu menu = new LaunchMenu();
            
            menu.Start();

        }
    }
}
