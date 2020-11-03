using System;
using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseUI.Lacrosse101Menus;

namespace lacrosseUI
{
    class Program
    {
        static void Main(string[] args)
        {
            lacrosseContext context = new lacrosseContext();
            IMenu menu = new LaunchMenu(context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
            menu.Start();
        }
    }
}
