namespace MVCLibraryApp.Models
{
    public class AbonnementModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int MaxItems { get; set; }
        public int ReturnTerm { get; set; }
        public int ProlongedTerm { get; set; }
        public decimal ReservationCosts { get; set; }
        public decimal FineCosts { get; set; }
        public decimal AbonnementsCosts { get; set; }

        public ICollection<VisitorModel> Visitors { get; set; }
    }
}
