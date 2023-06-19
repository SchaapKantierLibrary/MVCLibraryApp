namespace MVCLibraryApp.Models
{
    public class AbonnementModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int MaximaleItems { get; set; }
        public int Uitleentermijn { get; set; }
        public int Verlengingen { get; set; }
        public decimal Reserveringskosten { get; set; }
        public decimal Boetekosten { get; set; }
        public decimal Abonnementskosten { get; set; }

        public ICollection<BezoekerModel> Bezoekers { get; set; }
    }
}
