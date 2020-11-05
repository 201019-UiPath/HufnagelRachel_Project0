namespace lacrosseDB.Models
{
    /// <summary>
    /// The class inventory which acts as a join tables between location and products
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Property of the inventory class
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Property of the inventory class
        /// </summary>
        /// <value></value>
        public int quantityOfBalls { get; set; }

        /// <summary>
        /// Property of the inventory class
        /// </summary>
        /// <value></value>
        public int quantityOfSticks { get; set; }

        /// <summary>
        /// Property of the inventory class
        /// </summary>
        /// <value></value>
        public int locationId { get; set; }

        /// <summary>
        /// Property of the inventory class
        /// </summary>
        /// <value></value>
        public Locations location { get; set; }
    }
}