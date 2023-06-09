using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLibraryApp.Models
{
    public class LocatieModel
    {
        public int ID { get; set; }
        public string Beschrijving { get; set; }

        [NotMapped]
        public ICollection<ItemModel> Items { get; set; }
    }
}
