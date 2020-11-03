namespace lacrosseDB.Models
{
    /// <summary>
    /// The class sticks which inherits from the abstract class product
    /// </summary>
    public class Sticks : Product
    {
        /// <summary>
        /// Property of the sticks class
        /// </summary>
        /// <value></value>
        public BrandType brandType {get; set;}

        /// <summary>
        /// Property of the sticks class
        /// </summary>
        /// <value></value>
        public StickType stickType{get; set;} 

        /// <summary>
        /// Property of the sticks class
        /// </summary>
        /// <value></value>
        public int locationId {get; set;} 

        /// <summary>
        /// Property of the sticks class
        /// </summary>
        /// <value></value>
        public Locations location {get; set;}

        /// <summary>
        /// Enum for a property of brand type for the sticks class
        /// </summary>
        public enum BrandType {
            STX,
            Warrior, 
            DeBeer,
            Adidas,
        }
        
        /// <summary>
        /// Enum for a property of stick type for the sticks class
        /// </summary>
        public enum StickType {
            Womens, 
            Mens,
        }
        
    }
         
}