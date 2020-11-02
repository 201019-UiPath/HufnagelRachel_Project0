namespace lacrosseDB.Models
{
    /// <summary>
    /// The class balls which inherits from the abstract products class
    /// </summary>
    public class Balls : Product
    {
        /// <summary>
        /// Property of the balls class
        /// </summary>
        /// <value></value>
        public ColorType colorType { get; set; }
        /// <summary>
        /// Property of the balls class
        /// </summary>
        /// <value></value>
        public int locationId { get; set; }
        /// <summary>
        /// Property of the balls class
        /// </summary>
        /// <value></value>
        public Locations locations { get; set; }
        /// <summary>
        /// Enum for a property of color for the balls class
        /// </summary>
        public enum ColorType
        {
            Yellow,
            White,
        }

    }
}