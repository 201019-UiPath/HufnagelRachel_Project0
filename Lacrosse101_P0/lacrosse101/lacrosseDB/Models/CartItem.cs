namespace lacrosseDB.Models
{
    public class CartItem
    {
        public int Id {get; set;}
        public int cartId {get; set;} 
        public Cart cart {get; set;}
        public int ballId {get; set;} 
        public Balls ball {get; set;}
        public int stickId {get; set;}
        public Sticks stick {get; set;} 
        public int quantity {get; set;} 
    }
}