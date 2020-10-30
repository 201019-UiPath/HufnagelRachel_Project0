namespace lacrosseDB.Models
{
    public class Helments : Product
    {
        public string Color {get; set;}
        /// <summary>
        /// default constructor for the product helements
        /// </summary>
        public Helments() {
            Color = "";
        }
        
    }
}
