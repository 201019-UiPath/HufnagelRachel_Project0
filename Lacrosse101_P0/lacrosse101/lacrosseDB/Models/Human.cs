namespace lacrosseDB
{
    public abstract class Human
    {
        public int Id {get; set;} 
        public string FirstName{get; set;}
        public string LastName{get; set;}
        
        public Locations locations {get; set;}

    }
}