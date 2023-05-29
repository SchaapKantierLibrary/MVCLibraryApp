namespace MVCLibraryApp.Models
{
    public class ReserveringModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int BezoekerID { get; set; }

        public BezoekerModel Bezoeker { get; set; }
        public ItemModel Item { get; set; }
    }
}
