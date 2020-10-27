namespace lacrosseDB
{
    public class MouthGaurds : Product
    {
        public string Color {get; set;}
        public bool Molded {get; set;}
        /// <summary>
        /// default constructor for the product mouth gaurds
        /// </summary>
        public MouthGaurds() {
            Color = "";
            Molded = false;
        }
    }
}