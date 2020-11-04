using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public class ValidInvalidServices
    {

        public static Boolean InvalidQuanityOfItems(int locationQuan, int customerQuan)
        {
            if (locationQuan < customerQuan)
            {
                Console.WriteLine("You are trying to purchas an item that is not valid");
                Console.WriteLine($"You have {(customerQuan - locationQuan)} too many item(s)");
                return false;
            }
            return true;
        }

        public static void InvalidInput()
        {
            Console.WriteLine("Invalid, please try again");
        }

        public void InvalidEmail()
        {
            Console.WriteLine("You have entered and invalid email, try again.");
        }

        public static Boolean ValidUniqueEmail(string email, List<Customer> custs)
        {
            if (Regex.IsMatch(email, @"^[a-z0-9.]+@[a-z0-9]+[\.][a-z]", RegexOptions.IgnoreCase))
            {
                foreach (Customer cust in custs)
                {
                    if (cust.email == email)
                    {
                        Console.WriteLine("The email is already being used by another customer, try again.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("The email address entered is not a vaild email address.");
                return false;
            }
            return false;
        }
    }
}