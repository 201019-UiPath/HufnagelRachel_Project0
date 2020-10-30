namespace lacrosseDB.Models
{
    public class Orders
    {
        #region Definitions
        // primary key for orders
        public int Id {get; set;}
        // this needs to be parsed into an int maybeeeee 
        public string OrderNum {get; set;}
        public int Quanity {get; set;}
        public double TotalPrice {get; set;}
        // the two foregin keys
        public int LocationId {get; set;}
        public int CustomersId {get; set;}
        #endregion
        #region Constructors
        // default constructor 
        public Orders() {
            
        }
        // parameterized constructor
        public Orders(int Id, string OrderNum, int Quanity, double TotalPrice, int LocationId, int CustomersId) {
            this.Id = Id; 
            this.OrderNum = OrderNum; 
            this.Quanity = Quanity;
            this.TotalPrice = TotalPrice; 
            this.LocationId = LocationId;
            this.CustomersId = CustomersId;

        } 
        #endregion
    }
}