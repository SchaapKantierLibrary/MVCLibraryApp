using System.ComponentModel.DataAnnotations;

namespace MVCLibraryApp.Models
{
    public class MoneyBank
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalEarnings { get; set; }
    }
}
