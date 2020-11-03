namespace lacrosseDB.Models
{
    /// <summary>
    /// The abstract class products in which all the products of the store will extend
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Property of the product class
        /// </summary>
        /// <value></value>
        public int Id {get; set;}
        
        /// <summary>
        /// Property of the product class
        /// </summary>
        /// <value></value>
        public float Price {get; set;} 
        
 
        
    }
}