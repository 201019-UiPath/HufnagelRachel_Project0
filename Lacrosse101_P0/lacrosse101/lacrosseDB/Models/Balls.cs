namespace lacrosseDB
{
    public class Balls : Product 
    {
        // allow for only two colors yellow and white
        public string Color {get; set;}

        public Balls() {
            Color = "";
        }
    }
}