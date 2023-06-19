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

        public FactuurModel CalculateFineAndGenerateInvoice(LeningModel lending, BezoekerModel user)
        {
            var subscription = _context.Abonnementen.Find(user.AbonnementID);
            if (subscription == null)
                throw new Exception("Subscription not found");

            var overdueDays = (DateTime.Now - lending.Einddatum).Days;

            var fineAmount = overdueDays > 0 ? overdueDays * subscription.Boetekosten : 0;

            var geldbank = _context.Geldbank.FirstOrDefault();
            if (geldbank == null)
            {
                geldbank = new GeldbankModel();
                _context.Geldbank.Add(geldbank);
            }

            if (overdueDays > 0)
            {
                geldbank.TotalEarnings += fineAmount;
            }

            var existingInvoice = _context.Facturen.FirstOrDefault(f =>
                f.ItemID == lending.ItemID && f.UserId == user.Id);

            FactuurModel invoice;

            if (existingInvoice != null)
            {
                invoice = existingInvoice;
                invoice.Amount += fineAmount;
            }
            else
            {
                invoice = new FactuurModel
                {
                    UserId = user.Id,
                    ItemID = lending.ItemID,
                    Amount = fineAmount,
                    TransactionDate = DateTime.Now,
                    Description = $"Fine for overdue return of item {lending.ItemID}",
                    User = user
                };

                _context.Facturen.Add(invoice);
            }

            var reservationCost = subscription.Reserveringskosten;
            invoice.Amount += reservationCost;

            _context.SaveChanges();

            return invoice;
        }
    }
}
 