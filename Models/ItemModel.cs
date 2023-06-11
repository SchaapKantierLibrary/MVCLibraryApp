namespace MVCLibraryApp.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public int AuteurID { get; set; }
        public AuteurModel Auteur { get; set; }
        public int Publicatiejaar { get; set; }
        public string Status { get; set; }

        public int LocatieID { get; set; }
        public LocatieModel Locatie { get; set; }

        public ICollection<LeningModel> Lenings { get; set; }
        public ICollection<ReserveringModel> Reserverings { get; set; }
    }
}
