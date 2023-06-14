namespace MVCLibraryApp.Models
{
    public class ReservationModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string VisitorID { get; set; } // Change the type to string
        public DateTime ReservationDate { get; set; } // Add this line

        // Navigation property
        public VisitorModel Visitor { get; set; }
        public ItemModel Item { get; set; }
    }
}
