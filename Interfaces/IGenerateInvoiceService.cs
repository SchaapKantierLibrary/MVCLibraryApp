using MVCLibraryApp.Models;

namespace MVCLibraryApp.Interfaces
{
    public interface IGenerateInvoiceService
    {
        InvoiceModel CalculateFineAndGenerateInvoice(LoanModel lending, VisitorModel user);
    }
}
