namespace lacrosseDB
{
    public class MouthGaurds : Product
    {
        public string Color {get; set;}
        public bool Molded {get; set;}

        public MouthGaurds() {
            Color = "";
            Molded = false;
        }
    }
}