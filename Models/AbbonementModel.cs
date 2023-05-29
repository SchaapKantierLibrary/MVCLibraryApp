namespace MVCLibraryApp.Models
{
    public class AbonnementModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int MaximaleItems { get; set; }
        public int Uitleentermijn { get; set; }
        public int Verlengingen { get; set; }
        public double Reserveringskosten { get; set; }
        public double Boetekosten { get; set; }
        public double Abonnementskosten { get; set; }

        public ICollection<BezoekerModel> Bezoekers { get; set; }
    }
}
