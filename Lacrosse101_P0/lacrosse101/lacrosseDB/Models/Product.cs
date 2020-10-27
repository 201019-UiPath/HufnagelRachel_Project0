namespace lacrosseDB
{
    /// <summary>
    /// The abstract class in which all the products will extend
    /// </summary>
    public abstract class Product
    {
        public int PorductId {get; set;}
        public float Price {get; set;} 
        public string ProdName {get; set;}
        public Locations locations {get; set;}
        
    }
}