namespace lacrosseDB.Models
{
    /// <summary>
    /// The abstract class in which all the products will extend
    /// </summary>
    public abstract class Product
    {
        public int Id {get; set;}
        public float Price {get; set;} 
        public string ProdName {get; set;}
        public Locations locations {get; set;}
        
    }
}