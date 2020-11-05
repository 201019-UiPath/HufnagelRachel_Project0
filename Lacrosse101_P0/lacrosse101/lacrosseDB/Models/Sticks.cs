namespace lacrosseDB.Models
{
    /// <summary>
    /// The class sticks which inherits from the abstract class product
    /// </summary>
    public class Sticks : Product
    {
       public Sticks() 
       {
           ProductType = 0;
       }

       public Sticks(double Price, string description)
       {
           ProductType = 0;
           this.Price = Price;
           this.description = description;
       }

        
    }
         
}