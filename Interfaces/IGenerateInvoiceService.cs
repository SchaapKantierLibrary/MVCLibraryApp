using MVCLibraryApp.Models;

namespace MVCLibraryApp.Interfaces
{
    public interface IGenerateInvoiceService
    {
        FactuurModel CalculateFineAndGenerateInvoice(LeningModel lending, BezoekerModel user);
    }
}
