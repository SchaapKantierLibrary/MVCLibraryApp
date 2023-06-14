namespace MVCLibraryApp.Models
{
    public class LoanModel
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string VisitorID { get; set; } // Change the type to string

        // Navigation property
        public VisitorModel Visitor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public double FineCosts { get; set; }

        public ItemModel Item { get; set; }
    }
}
