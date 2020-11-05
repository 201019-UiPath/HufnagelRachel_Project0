using System.Collections.Generic;

namespace lacrosseDB.Models
{
    /// <summary>
    /// The abstract class products in which all the products of the store will inherit from
    /// </summary>
    public abstract class Product
    {
        public int Id {get; set;}
        public int ProductType {get; set;}
        public double Price {get; set;}
        public string description {get; set;}
        public List<Inventory> ProductLocation {get; set;}
        
    }
}