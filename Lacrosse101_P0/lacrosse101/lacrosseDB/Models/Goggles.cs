namespace lacrosseDB
{
  
    public class Goggles : Product
    {
        public string Brand {get; set;}
        public string Color {get; set;}

        /// <summary>
        /// the default constructor for the product googles
        /// </summary>
        public Goggles() {
            Brand = "";
            Color = "";
        }
    }
}