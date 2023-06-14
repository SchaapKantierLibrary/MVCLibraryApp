namespace MVCLibraryApp.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<LoanModel> Loans { get; set; }
        public ICollection<ReservationModel> Reservations { get; set; }
    }
}
