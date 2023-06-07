namespace MVCLibraryApp.Models
{
    public class ReserveringModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string BezoekerID { get; set; } // Change the type to string
        public DateTime ReservationDate { get; set; } // Add this line

        // Navigation property
        public BezoekerModel Bezoeker { get; set; }
        public ItemModel Item { get; set; }
    }
}
