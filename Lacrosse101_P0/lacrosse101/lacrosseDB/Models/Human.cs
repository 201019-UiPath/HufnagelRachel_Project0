namespace lacrosseDB.Models
{
    public abstract class Human
    {
        #region Definitions
        public int Id {get; set;} 
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public int LocationId {get; set;}
        #endregion

        #region Constructors 
        public Human() {

        }

        public Human(int Id, string FirstName, string LastName, int LocationId) {
            this.Id = Id; 
            this.FirstName = FirstName; 
            this.LastName = LastName; 
            this.LocationId = LocationId;
        }
        #endregion

    }
}