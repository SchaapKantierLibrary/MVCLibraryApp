namespace MVCLibraryApp.Models
{
    public class LeningModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string BezoekerID { get; set; } // Change the type to string

        // Navigation property
        public BezoekerModel Bezoeker { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Status { get; set; }
        public double Boetekosten { get; set; }

        public ItemModel Item { get; set; }
    }
}
