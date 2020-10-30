namespace lacrosseDB.Models
{
    public class Locations
    {
        #region Definitions
        public int Id {get; set;}
        public string StoreLocation {get; set;}
        #endregion

        #region Constructors
        public Locations() {

        }

        public Locations(int Id, string StoreLocation) {
            this.Id = Id; 
            this.StoreLocation = StoreLocation;
        }
        #endregion
        
    }
}

// might make this an abstract class but as of right now going to leave it 