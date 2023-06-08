using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryApp.Models
{
    public class BezoekerModel : IdentityUser
    {
        // IdentityUser already contains properties for Id, UserName (which could be used for Email), and PasswordHash (for Password)

        // Your existing properties
        public string Naam { get; set; }
        public string Lidmaatschapsstatus { get; set; } = "Free"; // Set a default value for Lidmaatschapsstatus

        public int AbonnementID { get; set; }
        public AbonnementModel Abonnement { get; set; }



        public ICollection<LeningModel> Lenings { get; set; }
        public ICollection<ReserveringModel> Reserverings { get; set; }
    }

}
