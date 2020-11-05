namespace lacrosseDB.Models
{
    /// <summary>
    /// The class balls which inherits from the abstract products class
    /// </summary>
    public class Balls : Product
    {
        public Balls() 
        {
            ProductType = 1;
        }

        public Balls(double Price, string description) 
        {
            ProductType = 1;
            this.Price = Price;
            this.description = description;
        }

    }
}