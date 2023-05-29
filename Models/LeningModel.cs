namespace MVCLibraryApp.Models
{
    public class LeningModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int BezoekerID { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Status { get; set; }
        public double Boetekosten { get; set; }

        public BezoekerModel Bezoeker { get; set; }
        public ItemModel Item { get; set; }
    }
}
