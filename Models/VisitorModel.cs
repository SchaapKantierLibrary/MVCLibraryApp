using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryApp.Models
{
    public class VisitorModel : IdentityUser
    {
        // IdentityUser already contains properties for Id, UserName (which could be used for Email), and PasswordHash (for Password)

        // Your existing properties
        public string Name { get; set; }

        public int AbonnementID { get; set; }
        public AbonnementModel Abonnement { get; set; }

        public ICollection<LoanModel> Loans { get; set; }
        public ICollection<ReservationModel> Reservations { get; set; }
    }

}
