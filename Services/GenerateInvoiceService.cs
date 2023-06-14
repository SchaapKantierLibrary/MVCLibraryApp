using MVCLibraryApp.Models;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Data;

namespace MVCLibraryApp.Services
{
    public class GenerateInvoiceService : IGenerateInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public GenerateInvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.InvoiceModel CalculateFineAndGenerateInvoice(LoanModel lending, VisitorModel user)
        {
            var subscription = _context.Abonnementen.Find(user.AbonnementID);
            if (subscription == null)
                throw new Exception("Subscription not found");

            var overdueDays = (DateTime.Now - lending.EndDate).Days;

            var fineAmount = overdueDays > 0 ? overdueDays * subscription.FineCosts : 0;

            var geldbank = _context.Geldbank.FirstOrDefault();
            if (geldbank == null)
            {
                geldbank = new MoneyBank();
                _context.Geldbank.Add(geldbank);
            }

            if (overdueDays > 0)
            {
                geldbank.TotalEarnings += fineAmount;
            }

            var existingInvoice = _context.Invoice.FirstOrDefault(f =>
                f.ItemID == lending.ItemID && f.UserId == user.Id);

            Models.InvoiceModel invoice;

            if (existingInvoice != null)
            {
                invoice = existingInvoice;
                invoice.Amount += fineAmount;
            }
            else
            {
                invoice = new Models.InvoiceModel
                {
                    UserId = user.Id,
                    ItemID = lending.ItemID,
                    Amount = fineAmount,
                    TransactionDate = DateTime.Now,
                    Description = $"Fine for overdue return of item {lending.ItemID}",
                    User = user
                };

                _context.Invoice.Add(invoice);
            }

            var reservationCost = subscription.ReservationCosts;
            invoice.Amount += reservationCost;

            _context.SaveChanges();

            return invoice;
        }
    }
}
 