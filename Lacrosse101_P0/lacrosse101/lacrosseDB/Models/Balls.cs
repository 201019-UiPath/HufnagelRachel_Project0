namespace lacrosseDB.Models
{
    public class Balls : Product 
    {
        // allow for only two colors yellow and white
        public string Color {get; set;}
        /// <summary>
        /// default constructor for lacrosse balls
        /// </summary>
        public Balls() {
            Color = "";
        }
    }
}