using System;

namespace lacrosseLib
{
    public class Customer : Human
    {
        public string CustomerId {get; set;}
        
        public string CustAddress {get; set;}

        // maybe need to keep track of the order number? 
    }
}
