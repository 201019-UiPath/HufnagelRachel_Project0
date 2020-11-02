using System.Collections.Generic;

namespace lacrosseDB.Models
{
    public class Cart
    {
        public int Id {get; set;}
        public int custId {get; set;} 
        public Customer customer {get; set;} 
        public List<CartItem> cartItem {get; set;} 
    }
}