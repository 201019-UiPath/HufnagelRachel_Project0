using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;
using System;

namespace lacrosseUI.Lacrosse101Menus
{
    public class CustMenu : IMenu
    {
        private string custInpt;
        private Customer customer;
        private OrderHistoryMenu orderHistoryMenu;
        private ProductDetails productDetails;
        private CheckoutMenu checkout;

        public CustMenu(Customer customer, lacrosseContext context)
        {
            this.customer = customer;
            this.orderHistoryMenu = new OrderHistoryMenu(customer, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
            this.productDetails = new ProductDetails(customer, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
            this.checkout = new CheckoutMenu(customer, context,new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context),new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("Please select one of the options below: ");
                Console.WriteLine("[0] Exit \n[2] View Order History \n[4] Browse Products \n[6] View Cart");
                switch (custInpt)
                {
                    case "0":
                        break;

                    case "2":
                        orderHistoryMenu.Start();
                        break;

                    case "4":
                        productDetails.Start();
                        break;

                    case "6":
                        checkout.Start();
                        break;

                    default:
                        ValidInvalidServices.InvalidInput();
                        break;

                }
            } while (!(custInpt.Equals("0")));
        }
    }
}