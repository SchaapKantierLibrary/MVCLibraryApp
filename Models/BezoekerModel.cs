namespace MVCLibraryApp.Models
{
    public class BezoekerModel
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Lidmaatschapsstatus { get; set; }

        public int AbonnementID { get; set; }
        public AbonnementModel Abonnement { get; set; }

        public ICollection<LeningModel> Lenings { get; set; }
        public ICollection<ReserveringModel> Reserverings { get; set; }
    }
}
