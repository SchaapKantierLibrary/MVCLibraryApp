namespace MVCLibraryApp.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public AuthorModel Author { get; set; }
        public int PublicationYear { get; set; }
        public string Status { get; set; }

        public int LocationID { get; set; }
        public LocationModel Location { get; set; }

        public ICollection<LoanModel> Loans { get; set; }
        public ICollection<ReservationModel> Reservations { get; set; }
    }
}
