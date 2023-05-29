namespace MVCLibraryApp.Models
{
    public class MedewerkerModel
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public ICollection<LeningModel> Lenings { get; set; }
        public ICollection<ReserveringModel> Reserverings { get; set; }
    }
}
