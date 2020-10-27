namespace lacrosseDB
{
    public class WSticks : Product
    {
        // need to check input for aloud brands 
        public string Brand {get; set;}

        /// <summary>
        /// default constructor for the product womens sticks
        /// </summary>
        public WSticks() {
            Brand = "";
        }
        
    }
}