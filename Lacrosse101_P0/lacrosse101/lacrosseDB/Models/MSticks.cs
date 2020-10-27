namespace lacrosseDB
{
    public class MSticks : Product
    {
        // the stick can either be attack, mid-field, defence
        // need to make sure only these strings are allowed 
        public string StickType {get; set;}
        // same thing here need to make sure only select brands are aloud for input 
        // otherwise throw and excpetion 
        public string Brand {get; set;}
        /// <summary>
        /// default constructor for the product mens sticks 
        /// </summary>
        public MSticks() {
            StickType = "";
            Brand = "";
        }
        
    }
}