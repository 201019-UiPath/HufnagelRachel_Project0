using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using System;

namespace lacrosseUI.Lacrosse101Menus
{
    public class CustMenu : IMenu
    {
        private string custInpt;
        private Customer customer;
        private OrderHistoryMenu orderHistoryMenu;
        //products menu and cart menu to add

        public CustMenu(Customer customer, lacrosseContext context)
        {
            this.customer = customer;
            this.orderHistoryMenu = new OrderHistoryMenu(customer, context, new DBRepo(context),new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }

        public void Start()
        {
            Console.WriteLine("Please select one of the options below: ");
            Console.WriteLine("[0] Exit \n[2] View Order History \n[4] View Products \n[6] View Cart");
        }
    }
}