namespace lacrosseDB.Models
{
    public class Sticks : Product
    {
        public string Brand {get; set;}
        public bool isMensStick {get; set;}

        /// <summary>
        /// default constructor for the product womens sticks
        /// </summary>
        public Sticks() {
            Brand = "";
            isMensStick = false;
        }
        
    }
}