using System;

namespace lacrosseDB.Models
{
    /// <summary>
    /// Customer class which extends the abstract class human
    /// </summary>
    public class Customer : Human
    {   
        public string CustAddress {get; set;}

        // maybe need to keep track of the order number? 
        
    }
}
