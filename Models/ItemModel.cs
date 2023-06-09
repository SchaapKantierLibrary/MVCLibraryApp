using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLibraryApp.Models
{
    public class ItemModel
    {
        public ItemModel()
        {
            Status = "Available";
            Lenings = new List<LeningModel>();
            Reserverings = new List<ReserveringModel>();
        }

        public int ID { get; set; }
        public string Titel { get; set; }
        public int AuteurID { get; set; }
       
        public int Publicatiejaar { get; set; }
        public string Status { get; set; }

        public int LocatieID { get; set; }

        [NotMapped]
        public LocatieModel Locatie { get; set; }
        [NotMapped]
        public AuteurModel Auteur { get; set; }

        [NotMapped]
        public ICollection<LeningModel> Lenings { get; set; }
        [NotMapped]
        public ICollection<ReserveringModel> Reserverings { get; set; }
    }
}